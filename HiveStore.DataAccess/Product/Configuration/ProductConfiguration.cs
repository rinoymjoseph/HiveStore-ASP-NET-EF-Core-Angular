using HiveStore.Entity.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.DataAccess.Product.Configuration
{
    public class ProductConfiguration<TEntity> : BasicEntityConfiguration, IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product", "hive");

            builder.Property(p => p.Id).HasColumnName("PRODUCT_ID");
            builder.Property(p => p.ProductName).HasColumnName("PRODUCT_NAME").HasMaxLength(200).IsRequired();
            builder.Property(p => p.UnitPrice).HasColumnName("UNIT_PRICE");

            ConfigureBase(builder);
        }
    }
}
