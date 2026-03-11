namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Excluir;

public class AlunoExcluirResponse(string id, string mensagem)
{
    public string Id { get; } = id;
    public string Mensagem { get; } = mensagem;
}
