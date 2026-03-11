using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Adicionar;

public class AlunoAdicionarRequest : IRequest<CommandResponse<AlunoAdicionarResponse>>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public int Idade { get; set; }
}
