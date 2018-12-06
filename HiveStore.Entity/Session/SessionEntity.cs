using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Entity.Session
{
    public class SessionEntity
    {
        public string Id { get; set; }
        public Byte[] Value { get; set; }
        public DateTimeOffset ExpiresAtTime { get; set; }
        public Int64? SlidingExpirationInSeconds { get; set; }
        public DateTimeOffset? AbsoluteExpiration { get; set; }
    }
}
