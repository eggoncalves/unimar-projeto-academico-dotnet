using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Excluir;

public class AlunoExcluirRequest(string id) : IRequest<CommandResponse<AlunoExcluirResponse>>
{
    public string Id { get; } = id;
}
