using Unimar.ProjetoAcademico.Domain.Enumerators;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;

public class CursoObterResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public EnumPeriodo Periodo { get; set; }
    public string? Descricao { get; set; }
    public int CargaHoraria { get; set; }
    public int QuantidadeMaximaAlunos { get; set; }
}