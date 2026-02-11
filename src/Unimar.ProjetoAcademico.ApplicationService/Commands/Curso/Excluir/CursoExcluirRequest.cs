using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;

public class CursoExcluirRequest(Guid id) : IRequest<CommandResponse<CursoExcluirResponse>>
{
    public Guid Id { get; } = id;
}