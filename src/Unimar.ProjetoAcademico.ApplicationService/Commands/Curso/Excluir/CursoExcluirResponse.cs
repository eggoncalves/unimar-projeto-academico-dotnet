namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;

public class CursoExcluirResponse(Guid id, string mensagem)
{
    public Guid Id { get; } = id;
    public string Mensagem { get; } = mensagem;
}
