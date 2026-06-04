using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecomerce.Infra.Data;
using Pacagroup.Ecomerce.Infra.Interface;


namespace Pacagroup.Ecomerce.Infra.Repository
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) 
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScope<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
