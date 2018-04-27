using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiveStoreNGCoreApp.Web.Models
{
    public class BaseResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string Response { get; set; }
        public string Message { get; set; }
    }
}
