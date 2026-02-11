using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unimar.ProjetoAcademico.ApplicationService.AppService;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.UoW;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.Data.Context;
using Unimar.ProjetoAcademico.Infra.Data.Repositories;
using Unimar.ProjetoAcademico.Infra.Data.UoW;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.IoC
{
    public static class RegisterIoC
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            
            services.AddScoped<IRepositoryCurso, RepositoryCurso>();

            #endregion

            #region Application Services

            services.AddScoped<IAppServiceCurso, AppServiceCurso>();

            #endregion

            #region Unit of Work

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion

            #region Context    

            services.AddDbContext<ProjetoAcademicoContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("UnimarProjetoAcademicoConnection"));
            });

            #endregion

            return services;
        }
    }
}
