using HiveStore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace HiveStore.IHelper
{
    public interface IRequestInfoHelper
    {
        RequestInfo GetRequestInfo(IHttpConnectionFeature httpConnectionFeature);
        void BindRequestInfo(HttpContext httpContext, BaseResponseDTO baseResponseDTO);
    }
}
