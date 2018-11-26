using HiveStore.DataAccess;
using HiveStore.Helper;
using HiveStore.IHelper;
using HiveStore.IRepository.Employee;
using HiveStore.IRepository.Product;
using HiveStore.IService.Employee;
using HiveStore.IService.Product;
using HiveStore.Repository.Employee;
using HiveStore.Repository.Product;
using HiveStore.Service.Employee;
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
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<HiveDataContext>()
                .AddDefaultTokenProviders();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        private static void ConfigureHelpers(IServiceCollection services)
        {
            services.AddScoped<IServerInfoHelper, ServerInfoHelper>();
        }
    }
}
