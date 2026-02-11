using Unimar.ProjetoAcademico.Domain.Entities;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.Data.Context;
using Unimar.ProjetoAcademico.Infra.Data.Repositories.Base;

namespace Unimar.ProjetoAcademico.Infra.Data.Repositories
{
    public class RepositoryAluno(ProjetoAcademicoContext context) : RepositoryBase<ProjetoAcademicoContext, Aluno, int>(context), IRepositoryAluno;
}
