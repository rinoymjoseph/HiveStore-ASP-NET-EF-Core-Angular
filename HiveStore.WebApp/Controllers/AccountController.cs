using HiveStore.DTO;
using HiveStore.Entity.Identity;
using HiveStore.IHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace HiveStore.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("AccountAPI")]
    public class AccountController : Controller
    {
        private readonly IRequestInfoHelper _requestInfoHelper;
        private readonly SignInManager<UserEntity> _signInManager;

        public AccountController(IRequestInfoHelper requestInfoHelper, SignInManager<UserEntity> signInManager)
        {
            _requestInfoHelper = requestInfoHelper;
            _signInManager = signInManager;
        }

        [Route("SignIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignInDTO signInDTO)
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                var result = await _signInManager.PasswordSignInAsync(signInDTO.UserName, signInDTO.Password, true, false);
                baseResponseDTO.IsSuccess = true;
                HttpContext.Session.SetString("SignedInTime", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"));
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }
            return Ok(baseResponseDTO);
        }

        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                await _signInManager.SignOutAsync();
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
        [Route("GetSignedInUser")]
        public IActionResult GetSignedInUser()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

            try
            {
                UserDTO userDTO = new UserDTO();
                userDTO.UserName = User.Identity.Name;
                baseResponseDTO.Response = JsonConvert.SerializeObject(userDTO);
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