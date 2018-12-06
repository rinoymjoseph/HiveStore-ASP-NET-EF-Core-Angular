﻿using HiveStore.DataAccess.Configuration.Order;
using HiveStore.DataAccess.Configuration.Product;
using HiveStore.DataContext.Configuration.Identity;
using HiveStore.DataContext.Configuration.Session;
using HiveStore.Entity.Identity;
using HiveStore.Entity.Order;
using HiveStore.Entity.Product;
using HiveStore.Entity.Session;
using Microsoft.AspNetCore.Identity;
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=JOSEPHR2\SQLEXPRESS;Database=HIVE;Trusted_Connection=True");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customizations must go after base.OnModelCreating(builder)

            builder.ApplyConfiguration(new UserConfiguration<UserEntity>());
            builder.ApplyConfiguration(new RoleConfiguration<IdentityRole>());
            builder.ApplyConfiguration(new UserRoleConfiguration<IdentityUserRole<string>>());
            builder.ApplyConfiguration(new RoleClaimConfiguration<IdentityRoleClaim<string>>());
            builder.ApplyConfiguration(new UserClaimConfiguration<IdentityUserClaim<string>>());
            builder.ApplyConfiguration(new UserLoginConfiguration<IdentityUserLogin<string>>());
            builder.ApplyConfiguration(new UserTokenConfiguration<IdentityUserToken<string>>());
            builder.ApplyConfiguration(new SessionConfiguration<SessionEntity>());

            builder.ApplyConfiguration(new ProductConfiguration<ProductEntity>());
            builder.ApplyConfiguration(new OrderConfiguration<OrderEntity>());
            builder.ApplyConfiguration(new OrderDetailsConfiguration<OrderDetailsEntity>());

            // Imagine a ton more customizations
        }

    }
}
