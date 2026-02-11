using Unimar.ProjetoAcademico.Domain.Entities.Base;
using Unimar.ProjetoAcademico.Domain.Enumerators;

namespace Unimar.ProjetoAcademico.Domain.Entities
{
    public class Curso : EntityBase<Guid>
    {
        public string Nome { get; set; } = string.Empty;
        public EnumPeriodo Periodo { get; set; }
        public string? Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public int QuantidadeMaximaAlunos { get; set; }
    }
}
