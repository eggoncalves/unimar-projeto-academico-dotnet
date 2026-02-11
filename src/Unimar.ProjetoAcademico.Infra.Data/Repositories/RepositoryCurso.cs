using Unimar.ProjetoAcademico.Domain.Entities;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.Data.Context;
using Unimar.ProjetoAcademico.Infra.Data.Repositories.Base;

namespace Unimar.ProjetoAcademico.Infra.Data.Repositories
{
    public class RepositoryCurso(ProjetoAcademicoContext context) : RepositoryBase<ProjetoAcademicoContext, Curso, Guid>(context), IRepositoryCurso;
}
