using HiveStore.Entity.Order;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HiveStore.Entity.Identity
{
    public class UserEntity : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<OrderEntity> OrderEntities { get; set; }
    }
}
