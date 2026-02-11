using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.FluentValidation;

public static class RegisterFluentValitation
{
    public static IServiceCollection AddFluentValitationAutoValidation(this IServiceCollection services, Assembly[] assemblies)
    {
        services
            .AddFluentValidationAutoValidation(config =>
            {
                config.OverrideDefaultResultFactoryWith<CustomResultFactory>();
            })
            .AddValidatorsFromAssemblies(assemblies);

        return services;
    }
}