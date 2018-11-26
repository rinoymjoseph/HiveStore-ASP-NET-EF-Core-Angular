using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiveStore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HiveStore.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("InfrastructureAPI")]
    public class InfrastructureController : Controller
    {
        [Route("GetRequestInfo")]
        [HttpGet]
        public IActionResult GetRequestInfo()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();

            try
            {
                var httpConnectionFeature = HttpContext.Features.Get<IHttpConnectionFeature>();
                RequestInfo requestInfo = new RequestInfo();
                requestInfo.ConnectionId = httpConnectionFeature.ConnectionId;
                requestInfo.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
                requestInfo.LocalPort = httpConnectionFeature.LocalPort;
                requestInfo.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
                requestInfo.RemotePort = httpConnectionFeature.RemotePort;
                requestInfo.RequestPath = HttpContext.Request.Path.Value;
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(requestInfo);
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