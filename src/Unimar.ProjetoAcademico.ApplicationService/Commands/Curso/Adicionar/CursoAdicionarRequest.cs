using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Enumerators;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar
{
    public class CursoAdicionarRequest : IRequest<CommandResponse<CursoAdicionarResponse>>
    {
        public string Nome { get; set; } = string.Empty;
        public EnumPeriodo Periodo { get; set; }
        public string? Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public int QuantidadeMaximaAlunos { get; set; }
    }
}