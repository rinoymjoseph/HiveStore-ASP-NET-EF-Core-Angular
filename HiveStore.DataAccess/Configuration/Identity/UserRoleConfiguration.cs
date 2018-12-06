using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HiveStore.DataContext.Configuration.Identity
{
    public class UserRoleConfiguration<TEntity> : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.ToTable("USER_ROLE", "HIVE");
            builder.Property(p => p.UserId).HasColumnName("USER_ID");
            builder.Property(p => p.RoleId).HasColumnName("ROLE_ID");
        }
    }
}
