using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;

public class CursoObterRequest(Guid id) : IRequest<CommandResponse<CursoObterResponse>>
{
    public Guid Id { get; } = id;
}