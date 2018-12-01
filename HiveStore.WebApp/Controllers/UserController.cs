using HiveStore.DTO;
using HiveStore.Entity.Identity;
using HiveStore.IHelper;
using HiveStore.IService.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiveStore.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("UserAPI")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRequestInfoHelper _requestInfoHelper;

        public UserController(IUserService userService, IRequestInfoHelper serverInfoHelper)
        {
            _userService = userService;
            _requestInfoHelper = serverInfoHelper;
        }

        [Route("GetAllUsers")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            List<UserEntity> userList;
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                userList = _userService.GetAllUsers();
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(userList);
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }

            return Ok(baseResponseDTO);
        }

        [Route("SaveUser")]
        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] UserEntity userEntity)
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                var result = await _userService.SaveUser(userEntity);         
                baseResponseDTO.IsSuccess = true;
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }
            return Ok(baseResponseDTO);
        }

        [Route("AddAdminUser")]
        [HttpGet]
        public async Task<IActionResult> AddAdminUser()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();

            try
            {
                var result = await _userService.AddAdminUser();
                baseResponseDTO.IsSuccess = true;
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