using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Unimar.ProjetoAcademico.Domain.Entities;
using Unimar.ProjetoAcademico.Infra.CrossCutting.NotificationPattern.DTOs;

namespace Unimar.ProjetoAcademico.Infra.Data.Context
{
    public class ProjetoAcademicoContext(DbContextOptions<ProjetoAcademicoContext> options) : DbContext(options)
    {
        public DbSet<Curso> CursoSet { get; set; }
        public DbSet<Aluno> AlunoSet { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<Enum>().HaveConversion<string>();
            base.ConfigureConventions(configurationBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            //1 a 1
            //modelBuilder.ApplyConfiguration(new CursoConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
