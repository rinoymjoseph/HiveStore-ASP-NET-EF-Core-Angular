using HiveStore.DTO;
using HiveStore.IHelper;
using Microsoft.AspNetCore.Http.Features;
using System;

namespace HiveStore.Helper
{
    public class ServerInfoHelper : IServerInfoHelper
    {
        public ServerInfo GetServerInfo(IHttpConnectionFeature httpConnectionFeature)
        {
            ServerInfo serverInfo = new ServerInfo();
            serverInfo.ConnectionId = httpConnectionFeature.ConnectionId;
            serverInfo.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
            serverInfo.LocalPort = httpConnectionFeature.LocalPort;
            serverInfo.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
            serverInfo.RemotePort = httpConnectionFeature.RemotePort;
            return serverInfo;
        }

        public void BindServerInfo(IHttpConnectionFeature httpConnectionFeature, BaseResponseDTO baseResponseDTO)
        {
            try
            {
                baseResponseDTO.ConnectionId = httpConnectionFeature.ConnectionId;
                baseResponseDTO.LocalIpAddress = httpConnectionFeature.LocalIpAddress.MapToIPv4().ToString();
                baseResponseDTO.LocalPort = httpConnectionFeature.LocalPort;
                baseResponseDTO.RemoteIpAddress = httpConnectionFeature.RemoteIpAddress.MapToIPv4().ToString();
                baseResponseDTO.RemotePort = httpConnectionFeature.RemotePort;
            }
            catch (Exception)
            {

            }
        }
    }
}
