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
        [Route("GetServerInfo")]
        [HttpGet]
        public IActionResult GetServerInfo()
        {
            BaseResponseDTO baseResponseDTO = new BaseResponseDTO();

            try
            {
                var httpConnectionFeature = HttpContext.Features.Get<IHttpConnectionFeature>();
                ServerInfo serverInfo = new ServerInfo();
                serverInfo.ConnectionId = httpConnectionFeature.ConnectionId;
                serverInfo.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
                serverInfo.LocalPort = httpConnectionFeature.LocalPort;
                serverInfo.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
                serverInfo.RemotePort = httpConnectionFeature.RemotePort;
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(serverInfo);
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