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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HiveStore.Extension
{
    public static class HiveStoreDI
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HiveDataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IServerInfoHelper, ServerInfoHelper>();
        }

        public static void ConfigureServices()
        {

        }

        public static void ConfigureRepositories()
        {

        }

        public static void ConfigureHelpers()
        {

        }
    }
}
