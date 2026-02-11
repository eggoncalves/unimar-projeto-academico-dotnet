using Unimar.ProjetoAcademico.ApplicationService.Interfaces.UoW;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;
using Unimar.ProjetoAcademico.Infra.Data.Context;

namespace Unimar.ProjetoAcademico.Infra.Data.UoW;

public class UnitOfWork(ProjetoAcademicoContext context) : ServiceNotification, IUnitOfWork
{
    public async Task<int> CommitAsync()
    {
        try
        {
            return await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            AddNotification("Database", ex.InnerException == null ? ex.Message : $"{ex.Message} - {ex.InnerException.Message}");
            return 0;
        }
    }
}