using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unimar.ProjetoAcademico.ApplicationService.AppService;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.UoW;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.Data.Context;
using Unimar.ProjetoAcademico.Infra.Data.Firebase;
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
            services.AddScoped<IRepositoryAlunoFb, RepositoryAlunoFb>();

            #endregion

            #region Application Services

            services.AddScoped<IAppServiceCurso, AppServiceCurso>();
            services.AddScoped<IAppServiceAlunoFb, AppServiceAlunoFb>();

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

            #region Firebase

            var firebaseOptions = new FirebaseOptions
            {
                ApiKey = configuration["Firebase:ApiKey"] ?? string.Empty,
                ProjectId = configuration["Firebase:ProjectId"] ?? string.Empty,
                ServiceAccountPath = configuration["Firebase:ServiceAccountPath"] ?? string.Empty
            };

            services.AddSingleton(provider =>
            {
                var googleCredential =
                    CredentialFactory
                        .FromFile<ServiceAccountCredential>(firebaseOptions.ServiceAccountPath)
                        .ToGoogleCredential();

                var db = new FirestoreDbBuilder
                {
                    ProjectId = firebaseOptions.ProjectId,
                    Credential = googleCredential
                }.Build();

                return db;
            });

            #endregion

            return services;
        }
    }
}
