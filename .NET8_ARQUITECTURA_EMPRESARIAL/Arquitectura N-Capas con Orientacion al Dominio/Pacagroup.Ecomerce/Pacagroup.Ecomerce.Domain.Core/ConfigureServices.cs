using Microsoft.Extensions.DependencyInjection;
using Pacagroup.Ecomerce.Domain.Interface;

namespace Pacagroup.Ecomerce.Domain.Core
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services) 
        {
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            return services;
        }
    }
}
