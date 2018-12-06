using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HiveStore.DataContext.Configuration.Identity
{
    public class RoleClaimConfiguration<TEntity> : IEntityTypeConfiguration<IdentityRoleClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> builder)
        {
            builder.ToTable("ROLE_CLAIM", "HIVE");
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.RoleId).HasColumnName("ROLE_ID");
            builder.Property(p => p.ClaimType).HasColumnName("CLAIM_TYPE");
            builder.Property(p => p.ClaimValue).HasColumnName("CLAIM_VALUE");
        }
    }
}
