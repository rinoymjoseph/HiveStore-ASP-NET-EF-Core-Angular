using HiveStore.Entity.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.DataAccess.Configuration.Order
{
    public class OrderDetailsConfiguration<TEntity> : BasicEntityConfiguration, IEntityTypeConfiguration<OrderDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
        {
            builder.ToTable("OrderDetails", "hive");
            builder.Property(p => p.Id).HasColumnName("ORDER_DETAILS_ID");
            builder.Property(p => p.OrderId).HasColumnName("ORDER_ID");
            builder.Property(p => p.ProductId).HasColumnName("PRODUCT_ID");
            builder.Property(p => p.UnitPrice).HasColumnName("UNIT_PRICE").HasColumnType("decimal(7,2)");
            builder.Property(p => p.Quantity).HasColumnName("QUANTITY");
            builder.Property(p => p.Discount).HasColumnName("DISCOUNT").HasColumnType("decimal(2,2)");
            ConfigureBase(builder);
        }
    }
}
