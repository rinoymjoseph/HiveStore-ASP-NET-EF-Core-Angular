using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HiveStore.DataContext.Configuration.Identity
{
    public class UserTokenConfiguration<TEntity> : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("USER_TOKEN", "HIVE");
            builder.Property(p => p.UserId).HasColumnName("USER_ID");
            builder.Property(p => p.LoginProvider).HasColumnName("LOGIN_PROVIDER");
            builder.Property(p => p.Name).HasColumnName("NAME");
            builder.Property(p => p.Value).HasColumnName("VALUE");
        }
    }
}
