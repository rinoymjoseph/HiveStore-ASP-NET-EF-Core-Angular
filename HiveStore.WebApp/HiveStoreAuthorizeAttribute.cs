using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace HiveStore.WebApp
{
    public class HiveStoreAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        List<String> allowedroles;

        public HiveStoreAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles.ToList();
        }

        /// <summary>
        /// Check for Authorization
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            allowedroles = this.Roles?.Split(',')?.ToList();
            IsUserAuthorized(authorizationFilterContext);
        }

        /// <summary>
        /// Method to check if the user is Authorized or not
        /// if yes continue to perform the action else redirect to error page
        /// </summary>
        /// <param name="filterContext"></param>
        private void IsUserAuthorized(AuthorizationFilterContext authorizationFilterContext)
        {
            bool authorize = false;

            if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)authorizationFilterContext.HttpContext.User.Identity;

                var userRoles = identity.Claims
                         .Where(c => c.Type == ClaimTypes.Role)
                         .Select(c => c.Value);

                if (this.Roles is null)
                {
                    authorize = true;
                }
                else
                {
                    if (allowedroles != null)
                    {
                        foreach (var role in allowedroles)
                        {
                            if (userRoles.Contains(role))
                            {
                                authorize = true;
                            }
                        }
                    }
                }

            }
            if (!authorize)
            {
                authorizationFilterContext.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
        }
    }

}
