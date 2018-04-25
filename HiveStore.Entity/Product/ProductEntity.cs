using HiveStore.Entity.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Entity.Product
{
    public class ProductEntity : BaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<OrderDetailsEntity> OrderDetails { get; set; }

    }
}
