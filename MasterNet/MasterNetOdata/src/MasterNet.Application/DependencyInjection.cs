using FluentValidation;
using MasterNet.Application.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MasterNet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services
    )
    {
        services.AddMediatR(configuration =>
        {
            configuration
            .RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        //services.AddFluentValidationAutoValidation();

        //services.AddValidatorsFromAssemblyContaining<CursoCreateCommand>();
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }

}