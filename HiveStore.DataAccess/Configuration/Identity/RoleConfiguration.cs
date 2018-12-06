using HiveStore.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiveStore.DataContext.Configuration.Identity
{
    public class RoleConfiguration<TEntity> : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("ROLE", "HIVE");
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.Name).HasColumnName("NAME");
            builder.Property(p => p.NormalizedName).HasColumnName("NORMALIZED_NAME");
            builder.Property(p => p.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
        }
    }
}
