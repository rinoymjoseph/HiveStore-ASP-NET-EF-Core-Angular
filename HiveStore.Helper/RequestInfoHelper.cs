using HiveStore.DTO;
using HiveStore.IHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;

namespace HiveStore.Helper
{
    public class RequestInfoHelper : IRequestInfoHelper
    {
        public RequestInfo GetRequestInfo(IHttpConnectionFeature httpConnectionFeature)
        {
            RequestInfo serverInfo = new RequestInfo();
            serverInfo.ConnectionId = httpConnectionFeature.ConnectionId;
            serverInfo.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
            serverInfo.LocalPort = httpConnectionFeature.LocalPort;
            serverInfo.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
            serverInfo.RemotePort = httpConnectionFeature.RemotePort;
            return serverInfo;
        }

        public void BindRequestInfo(HttpContext httpContext, BaseResponseDTO baseResponseDTO)
        {
            try
            {
                IHttpConnectionFeature httpConnectionFeature = httpContext.Features.Get<IHttpConnectionFeature>();
                baseResponseDTO.ConnectionId = httpConnectionFeature.ConnectionId;
                baseResponseDTO.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
                baseResponseDTO.LocalPort = httpConnectionFeature.LocalPort;
                baseResponseDTO.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
                baseResponseDTO.RemotePort = httpConnectionFeature.RemotePort;
                baseResponseDTO.RequestPath = httpContext.Request.Path.Value;
            }
            catch (Exception)
            {

            }
        }
    }
}
