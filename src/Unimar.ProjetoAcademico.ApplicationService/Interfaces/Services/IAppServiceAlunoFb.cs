using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Adicionar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Atualizar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Excluir;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Listar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Obter;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interfaces;

namespace Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services
{
    public interface IAppServiceAlunoFb : IServiceNotification
    {
        Task<CommandResponse<AlunoObterResponse>> Obter(AlunoObterRequest request);
        Task<CommandResponse<AlunoObterResponse>> ObterPorNome(AlunoObterRequest request);
        Task<CommandResponse<List<AlunoListarResponse>>> Listar(AlunoListarRequest request);
        Task<CommandResponse<AlunoAdicionarResponse>> Adicionar(AlunoAdicionarRequest request);
        Task<CommandResponse<AlunoAtualizarResponse>> Atualizar(AlunoAtualizarRequest request);
        Task<CommandResponse<AlunoExcluirResponse>> Excluir(AlunoExcluirRequest request);
    }
}
