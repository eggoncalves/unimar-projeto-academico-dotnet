using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.Swagger;

public static class RegisterSwagger
{
    public static void AddSwagger(this IServiceCollection services)
    {

        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Unimar - Projeto Acadêmico",
                Version = "File Version: v1.0.0"
            });
        });
    }
}