using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.DTO
{
    public class RequestInfo
    {
        public string ConnectionId { get; set; }
        public string RemoteIpAddress { get; set; }
        public string LocalIpAddress { get; set; }
        public int RemotePort { get; set; }
        public int LocalPort { get; set; }
        public string RequestPath { get; set; }
    }
}
