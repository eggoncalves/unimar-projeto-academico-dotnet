namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Listar;

public class CursoListarResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
}