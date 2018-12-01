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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HiveStore.Extension
{
    public static class HiveStoreDI
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDBContexts(services, configuration);
            ConfigureIdentity(services);
            ConfigureRepositories(services);
            ConfigureServices(services);
            ConfigureHelpers(services);
        }

        private static void ConfigureDBContexts(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HiveDataContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<UserEntity, IdentityRole>()
                .AddEntityFrameworkStores<HiveDataContext>()
                .AddDefaultTokenProviders();
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
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void ConfigureHelpers(IServiceCollection services)
        {
            services.AddScoped<IRequestInfoHelper, RequestInfoHelper>();
        }
    }
}
