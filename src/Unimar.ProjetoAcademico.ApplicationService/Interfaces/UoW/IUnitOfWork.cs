using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interfaces;

namespace Unimar.ProjetoAcademico.ApplicationService.Interfaces.UoW;

public interface IUnitOfWork : IServiceNotification
{
    Task<int> CommitAsync();
}