namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar
{
    public class CursoAdicionarResponse(Guid id, string mensagem)
    {
        public Guid Id { get; } = id;
        public string Mensagem { get; } = mensagem;
    }
}
