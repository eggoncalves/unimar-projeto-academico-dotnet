using Unimar.ProjetoAcademico.Domain.Entities.Base;

namespace Unimar.ProjetoAcademico.Domain.Entities;

public class AlunoFb : EntityBase<string>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public int Idade { get; set; }
}
