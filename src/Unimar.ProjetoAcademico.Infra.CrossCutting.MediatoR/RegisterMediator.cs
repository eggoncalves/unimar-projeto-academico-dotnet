using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.SimpleMediator;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.MediatoR;

public static class RegisterMediator
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly[] assemblies)
    {
        var unimarAssemblies = assemblies.Where(p => p.FullName != null && p.FullName.Contains("Unimar"));
        foreach (var assembly in unimarAssemblies)
        {
            services.AddSimpleMediator(assembly);
        }

        services.AddScoped<IMediator, Mediator>();

        return services;
    }
}

