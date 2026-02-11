using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Atualizar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Listar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification.Interfaces;

namespace Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;

public interface IAppServiceCurso : IServiceNotification
{
    Task<CommandResponse<CursoObterResponse>> Obter(CursoObterRequest request);
    Task<CommandResponse<List<CursoListarResponse>>> Listar(CursoListarRequest request);
    Task<CommandResponse<CursoAdicionarResponse>> Adicionar(CursoAdicionarRequest request);
    Task<CommandResponse<CursoAtualizarResponse>> Atualizar(CursoAtualizarRequest request);
    Task<CommandResponse<CursoExcluirResponse>> Excluir(CursoExcluirRequest request);
}
