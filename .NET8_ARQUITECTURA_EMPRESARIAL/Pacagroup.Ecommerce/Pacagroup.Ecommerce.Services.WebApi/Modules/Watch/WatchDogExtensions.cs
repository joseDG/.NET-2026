using WatchDog;
using WatchDog.src.Enums;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Watch
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWatchDog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(options =>
            {
                options.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
                options.DbDriverOption = WatchDogDbDriverEnum.MSSQL; // Usa la propiedad y enum correctos
                options.IsAutoClear = true;
                options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Monthly;
            });
            return services;
        }
    }
}
