using HiveStore.Entity.Identity;
using System;

namespace HiveStore.Entity.Order
{
    public class OrderEntity : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime RequiredDate { get; set; }
        public string ShipAddress { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
