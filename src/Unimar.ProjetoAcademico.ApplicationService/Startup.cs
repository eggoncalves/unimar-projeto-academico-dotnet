using Microsoft.Extensions.DependencyInjection;

namespace Unimar.ProjetoAcademico.ApplicationService;

public static class Startup
{
    public static void InitApplicationService(this IServiceCollection services)
    {
        Console.WriteLine("Iniciando Unimar Projeto Acadêmico Application Service...");
    }
}
