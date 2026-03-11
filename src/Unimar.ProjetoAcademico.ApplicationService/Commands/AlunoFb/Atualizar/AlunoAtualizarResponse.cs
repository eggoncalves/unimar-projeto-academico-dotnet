namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Atualizar;

public class AlunoAtualizarResponse(string id, string mensagem)
{
    public string Id { get; } = id;
    public string Mensagem { get; } = mensagem;
}
