namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Adicionar;

public class AlunoAdicionarResponse(string id, string mensagem)
{
    public string Id { get; } = id;
    public string Mensagem { get; } = mensagem;
}
