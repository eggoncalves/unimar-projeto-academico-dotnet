namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Obter;

public class AlunoObterResponse
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public int Idade { get; set; }
}
