using HiveStore.DataAccess.Configuration.Order;
using HiveStore.DataAccess.Configuration.Product;
using HiveStore.DataContext.Configuration.Identity;
using HiveStore.Entity.Identity;
using HiveStore.Entity.Order;
using HiveStore.Entity.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HiveStore.DataAccess
{
    public class HiveDataContext : IdentityDbContext<UserEntity>
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderDetailsEntity> OrderDetails { get; set; }

        public HiveDataContext(DbContextOptions<HiveDataContext> options)
  : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=JOSEPHR2\SQLEXPRESS;Database=Hive;Trusted_Connection=True");
        // }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customizations must go after base.OnModelCreating(builder)

            builder.ApplyConfiguration(new UserConfiguration<UserEntity>());
            builder.ApplyConfiguration(new ProductConfiguration<ProductEntity>());
            builder.ApplyConfiguration(new OrderConfiguration<OrderEntity>());
            builder.ApplyConfiguration(new OrderDetailsConfiguration<OrderDetailsEntity>());

            // Imagine a ton more customizations
        }

    }
}
