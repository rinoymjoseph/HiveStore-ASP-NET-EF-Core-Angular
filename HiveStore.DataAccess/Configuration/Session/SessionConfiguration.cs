using HiveStore.Entity.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiveStore.DataContext.Configuration.Session
{
    public class SessionConfiguration<TEntity> : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            builder.ToTable("USER_SESSION", "HIVE");
            builder.Property(p => p.Id).HasColumnName("Id").HasMaxLength(449);
            builder.Property(p => p.Value).HasColumnName("Value").IsRequired();
            builder.Property(p => p.ExpiresAtTime).HasColumnName("ExpiresAtTime");
            builder.Property(p => p.SlidingExpirationInSeconds).HasColumnName("SlidingExpirationInSeconds");
            builder.Property(p => p.AbsoluteExpiration).HasColumnName("AbsoluteExpiration");
        }
    }
}
