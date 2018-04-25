using HiveStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.DataAccess
{
    public abstract class BasicEntityConfiguration
    {
        public void ConfigureBase<TEntity>(EntityTypeBuilder<TEntity> builder)
         where TEntity : BaseEntity
        {
            builder.Property(p => p.CreatedDate).HasColumnName("CREATED_DATE").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(50).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnName("MODIFIED_DATE").IsRequired();
            builder.Property(p => p.ModifiedBy).HasColumnName("MODIFIED_BY").HasMaxLength(50).IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
            builder.Property(e => e.RecordTimeStamp).HasColumnName("RTS").IsRowVersion().IsRequired();
        }
    }
}
