using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveStore.DataContext.Configuration.Identity
{
    public class UserClaimConfiguration<TEntity> : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
        {
            builder.ToTable("USER_CLAIM", "HIVE");
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.UserId).HasColumnName("USER_ID");
            builder.Property(p => p.ClaimType).HasColumnName("CLAIM_TYPE");
            builder.Property(p => p.ClaimValue).HasColumnName("CLAIM_VALUE");
        }
    }
}
