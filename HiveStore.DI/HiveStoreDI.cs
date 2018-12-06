using HiveStore.DataAccess;
using HiveStore.Entity.Identity;
using HiveStore.Helper;
using HiveStore.IHelper;
using HiveStore.IRepository.Identity;
using HiveStore.IRepository.Product;
using HiveStore.IService.Identity;
using HiveStore.IService.Product;
using HiveStore.Repository.Identity;
using HiveStore.Repository.Product;
using HiveStore.Service.Identity;
using HiveStore.Service.Product;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;

namespace HiveStore.Extension
{
    public static class HiveStoreDI
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
        {
            ConfigureDBContexts(services, configuration);
            ConfigureSession(services, configuration,env);
            ConfigureIdentity(services, configuration);
            ConfigureRepositories(services);
            ConfigureServices(services);
            ConfigureHelpers(services);
        }

        private static void ConfigureDBContexts(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HiveDataContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void ConfigureSession(IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
        {
            //If Environment is Development then used Memorycache else use redis 
            if (env.IsDevelopment())
            {
                services.AddMemoryCache();
            }
            else
            {
                var redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"));
                services.AddDataProtection()
                    .SetApplicationName("HiveStoreApp")
                    .PersistKeysToRedis(redis, "DataProtection-Keys");
            }

            int loginExpireTimeSpan = Int32.Parse(configuration?.GetSection("AppSettings")?["LoginExpireTimeSpan"]);

            services.AddSession(options =>
            {
                options.Cookie.Name = ".HiveStoreWebApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(loginExpireTimeSpan);
            });
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("DefaultConnection");
                options.SchemaName = "HIVE";
                options.TableName = "USER_SESSION";
            });
        }

        private static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration)
        {
            int loginExpireTimeSpan = Int32.Parse(configuration?.GetSection("AppSettings")?["LoginExpireTimeSpan"]);

            services.AddIdentity<UserEntity, IdentityRole>()
                .AddEntityFrameworkStores<HiveDataContext>()
                .AddDefaultTokenProviders();

            services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(10));

            services.AddAuthentication()
                 .Services.ConfigureApplicationCookie(options =>
                {
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(loginExpireTimeSpan);
                });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }

        private static void ConfigureHelpers(IServiceCollection services)
        {
            services.AddScoped<IRequestInfoHelper, RequestInfoHelper>();
        }
    }
}
