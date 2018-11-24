using HiveStore.DTO;
using Microsoft.AspNetCore.Http.Features;

namespace HiveStore.IHelper
{
    public interface IServerInfoHelper
    {
        ServerInfo GetServerInfo(IHttpConnectionFeature httpConnectionFeature);
        void BindServerInfo(IHttpConnectionFeature httpConnectionFeature, BaseResponseDTO baseResponseDTO);
    }
}
