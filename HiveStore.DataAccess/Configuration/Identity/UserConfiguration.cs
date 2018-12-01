using HiveStore.DataAccess.Configuration;
using HiveStore.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiveStore.DataContext.Configuration.Identity
{
    public class UserConfiguration<TEntity> : BasicEntityConfiguration, IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            //builder.ToTable("User", "hive");
            builder.Property(p => p.Id).HasColumnName("USER_ID");
            builder.Property(p => p.FirstName).HasColumnName("FIRST_NAME").HasMaxLength(200).IsRequired();
            builder.Property(p => p.LastName).HasColumnName("LAST_NAME").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Address).HasColumnName("ADDRESS").HasMaxLength(200);
            builder.Property(p => p.City).HasColumnName("CITY").HasMaxLength(200);
            builder.Property(p => p.Country).HasColumnName("COUNTRY").HasMaxLength(200);
            builder.Property(p => p.CreatedDate).HasColumnName("CREATED_DATE").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(50).IsRequired();
            builder.Property(p => p.ModifiedDate).HasColumnName("MODIFIED_DATE").IsRequired();
            builder.Property(p => p.ModifiedBy).HasColumnName("MODIFIED_BY").HasMaxLength(50).IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        }
    }
}
