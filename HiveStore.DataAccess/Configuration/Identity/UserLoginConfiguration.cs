using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiveStore.DataContext.Configuration.Identity
{
    public class UserLoginConfiguration<TEntity> : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable("USER_LOGIN", "HIVE");
            builder.Property(p => p.LoginProvider).HasColumnName("LOGIN_PROVIDER");
            builder.Property(p => p.ProviderKey).HasColumnName("PROVIDER_KEY");
            builder.Property(p => p.ProviderDisplayName).HasColumnName("PROVIDER_DISPLAY_NAME");
            builder.Property(p => p.UserId).HasColumnName("USER_ID");
        }
    }
}
