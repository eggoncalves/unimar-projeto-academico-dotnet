namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Atualizar;

public class CursoAtualizarResponse(Guid id, string mensagem)
{
    public Guid Id { get; } = id;
    public string Mensagem { get; } = mensagem;
}