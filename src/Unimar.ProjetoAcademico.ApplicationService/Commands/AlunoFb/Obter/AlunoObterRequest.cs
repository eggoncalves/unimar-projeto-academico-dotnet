using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Obter;

public class AlunoObterRequest(string id) : IRequest<CommandResponse<AlunoObterResponse>>
{
    public string Id { get; } = id;
}
