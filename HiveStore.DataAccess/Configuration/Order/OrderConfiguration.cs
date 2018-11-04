using HiveStore.Entity.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.DataAccess.Configuration.Order
{
    public class OrderConfiguration<TEntity> : BasicEntityConfiguration, IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Order", "hive");

            builder.Property(p => p.Id).HasColumnName("ORDER_ID");
            builder.Property(p => p.EmployeeId).HasColumnName("EMPLOYEE_ID");
            builder.Property(p => p.RequiredDate).HasColumnName("REQUIRED_DATE");
            builder.Property(p => p.ShipAddress).HasColumnName("SHIP_ADDRESS");

            ConfigureBase(builder);
        }
    }
}
