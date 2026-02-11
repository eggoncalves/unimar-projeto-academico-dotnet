using Unimar.ProjetoAcademico.Domain.Entities.Base;

namespace Unimar.ProjetoAcademico.Domain.Entities;

public class Aluno : EntityBase<int>
{
    public string Nome { get; set; } = string.Empty;
}