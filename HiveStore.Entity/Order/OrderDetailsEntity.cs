using HiveStore.Entity.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Entity.Order
{
    public class OrderDetailsEntity : BaseEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Decimal Discount { get; set; }
        public virtual OrderEntity Order { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
