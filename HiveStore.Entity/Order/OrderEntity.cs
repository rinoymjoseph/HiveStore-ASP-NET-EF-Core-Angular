using HiveStore.Entity.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.Entity.Order
{
    public class OrderEntity : BaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime RequiredDate { get; set; }
        public string ShipAddress { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
    }
}
