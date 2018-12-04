using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiveStore.DTO;
using HiveStore.IHelper;
using HiveStore.IService.Identity;
using HiveStore.Service.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HiveStore.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("RoleAPI")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IRequestInfoHelper _requestInfoHelper;

        public RoleController(IRoleService roleService, IRequestInfoHelper requestInfoHelper)
        {
            _roleService = roleService;
            _requestInfoHelper = requestInfoHelper;
        }

        [HiveStoreAuthorize]
        [Route("SaveRole")]
        [HttpPost]
        public async Task<IActionResult> SaveRole([FromBody] IdentityRole identityRole)
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                var result = await _roleService.SaveRole(identityRole);
                baseResponseDTO.IsSuccess = true;
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }
            return Ok(baseResponseDTO);
        }

        [HiveStoreAuthorize]
        [Route("GetAllRoles")]
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<IdentityRole> identityRoleList;
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                identityRoleList = _roleService.GetAllRoles();
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(identityRoleList);
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }

            return Ok(baseResponseDTO);
        }

    }
}