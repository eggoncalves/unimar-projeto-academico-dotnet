using Microsoft.Extensions.DependencyInjection;

namespace Unimar.ProjetoAcademico.Domain;

public static class Startup
{
    public static void InitDomain(this IServiceCollection services)
    {
        Console.WriteLine("Iniciando Unimar Projeto Acadêmico Domain...");
    }
}
