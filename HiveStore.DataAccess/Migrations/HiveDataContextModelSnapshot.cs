﻿// <auto-generated />
using System;
using HiveStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HiveStore.DataContext.Migrations
{
    [DbContext(typeof(HiveDataContext))]
    partial class HiveDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HiveStore.Entity.Identity.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("CONCURRENCY_STAMP");

                    b.Property<string>("Name")
                        .HasColumnName("NAME")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("NORMALIZED_NAME")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NORMALIZED_NAME] IS NOT NULL");

                    b.ToTable("ROLE","HIVE");
                });

            modelBuilder.Entity("HiveStore.Entity.Identity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("ACCESS_FAILED_COUNT");

                    b.Property<string>("Address")
                        .HasColumnName("ADDRESS")
                        .HasMaxLength(200);

                    b.Property<string>("City")
                        .HasColumnName("CITY")
                        .HasMaxLength(200);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("CONCURRENCY_STAMP");

                    b.Property<string>("Country")
                        .HasColumnName("COUNTRY")
                        .HasMaxLength(200);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("EMAIL_CONFIRMED");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasMaxLength(200);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasMaxLength(200);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("LOCK_OUT_ENABLED");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("LOCK_OUT_END");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("NORMALIZED_EMAIL")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("NORMALIZED_USER_NAME")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("PASSWORD_HASH");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PHONE_NUMBER");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("PHONE_NUMBER_CONFIRMED");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("SECURITY_STAMP");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("TWO_FACTOR_ENABLED");

                    b.Property<string>("UserName")
                        .HasColumnName("USER_NAME")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NORMALIZED_USER_NAME] IS NOT NULL");

                    b.ToTable("USER","HIVE");
                });

            modelBuilder.Entity("HiveStore.Entity.Order.OrderDetailsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<decimal>("Discount")
                        .HasColumnName("DISCOUNT")
                        .HasColumnType("decimal(2,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<int>("OrderId")
                        .HasColumnName("ORDER_ID");

                    b.Property<int>("ProductId")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<int>("Quantity")
                        .HasColumnName("QUANTITY");

                    b.Property<byte[]>("RecordTimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("RTS");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("UNIT_PRICE")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ORDER_DETAILS","HIVE");
                });

            modelBuilder.Entity("HiveStore.Entity.Order.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<byte[]>("RecordTimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("RTS");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnName("REQUIRED_DATE");

                    b.Property<string>("ShipAddress")
                        .HasColumnName("SHIP_ADDRESS");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ORDER","HIVE");
                });

            modelBuilder.Entity("HiveStore.Entity.Product.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CREATED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnName("MODIFIED_BY")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("MODIFIED_DATE");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("PRODUCT_NAME")
                        .HasMaxLength(200);

                    b.Property<byte[]>("RecordTimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("RTS");

                    b.Property<double>("UnitPrice")
                        .HasColumnName("UNIT_PRICE");

                    b.HasKey("Id");

                    b.ToTable("PRODUCT","HIVE");
                });

            modelBuilder.Entity("HiveStore.Entity.Session.SessionEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasMaxLength(449);

                    b.Property<DateTimeOffset?>("AbsoluteExpiration")
                        .HasColumnName("AbsoluteExpiration");

                    b.Property<DateTimeOffset>("ExpiresAtTime")
                        .HasColumnName("ExpiresAtTime");

                    b.Property<long?>("SlidingExpirationInSeconds")
                        .HasColumnName("SlidingExpirationInSeconds");

                    b.Property<byte[]>("Value")
                        .IsRequired()
                        .HasColumnName("Value");

                    b.HasKey("Id");

                    b.ToTable("USER_SESSION","HIVE");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("CLAIM_TYPE");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("CLAIM_VALUE");

                    b.Property<int>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ROLE_CLAIM","HIVE");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnName("CLAIM_TYPE");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("CLAIM_VALUE");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("USER_CLAIM","HIVE");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("LOGIN_PROVIDER");

                    b.Property<string>("ProviderKey")
                        .HasColumnName("PROVIDER_KEY");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("PROVIDER_DISPLAY_NAME");

                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("USER_LOGIN","HIVE");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.Property<int>("RoleId")
                        .HasColumnName("ROLE_ID");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("USER_ROLE","HIVE");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("USER_ID");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("LOGIN_PROVIDER");

                    b.Property<string>("Name")
                        .HasColumnName("NAME");

                    b.Property<string>("Value")
                        .HasColumnName("VALUE");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("USER_TOKEN","HIVE");
                });

            modelBuilder.Entity("HiveStore.Entity.Order.OrderDetailsEntity", b =>
                {
                    b.HasOne("HiveStore.Entity.Order.OrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HiveStore.Entity.Product.ProductEntity", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HiveStore.Entity.Order.OrderEntity", b =>
                {
                    b.HasOne("HiveStore.Entity.Identity.UserEntity", "User")
                        .WithMany("OrderEntities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("HiveStore.Entity.Identity.RoleEntity")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("HiveStore.Entity.Identity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("HiveStore.Entity.Identity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("HiveStore.Entity.Identity.RoleEntity")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HiveStore.Entity.Identity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("HiveStore.Entity.Identity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
