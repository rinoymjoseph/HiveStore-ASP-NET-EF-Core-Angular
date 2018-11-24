using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiveStore.DTO
{
    public class BaseResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Response { get; set; }
        public string Message { get; set; }
        public string ConnectionId { get; set; }
        public string RemoteIpAddress { get; set; }
        public string LocalIpAddress { get; set; }
        public int RemotePort { get; set; }
        public int LocalPort { get; set; }
    }
}
