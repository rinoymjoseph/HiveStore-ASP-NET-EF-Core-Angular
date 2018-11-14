using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiveStore.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("AccountAPI")]
    public class AccountController : Controller
    {
        [Route("AzureADSignIn")]
        [HttpGet]
        public IActionResult AzureADSignIn()
        {
           // return Challenge("HiveStoreOpenIdAuthScheme");

            //var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            return Challenge(
                new AuthenticationProperties { RedirectUri = "/" },
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        //[Route("SignIn")]
        //[HttpPost]
        //[Consumes("application/x-www-form-urlencoded")]
        //public IActionResult SignIn([FromForm] string data)
        //{
        //    return Ok(User.Identity.Name);
        //    //return Challenge("HiveStoreOpenIdAuthScheme");
        //}

        //[Route("GetUserDetails")]
        //[HttpPost]
        //[Consumes("application/x-www-form-urlencoded")]
        //public IActionResult GetUserDetails([FromForm] string data)
        //{
        //    return Ok(User.Identity.Name);
        //    //return Challenge("HiveStoreOpenIdAuthScheme");
        //}


        [Route("GetUserDetails")]
        public IActionResult GetUserDetails()
        {
            return Ok(User.Identity.Name);
            //return Challenge("HiveStoreOpenIdAuthScheme");
        }
    }
}