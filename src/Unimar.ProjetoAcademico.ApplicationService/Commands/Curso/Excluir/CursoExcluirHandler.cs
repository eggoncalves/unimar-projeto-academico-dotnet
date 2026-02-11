using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;

public class CursoExcluirHandler(
    IRepositoryCurso repositoryCurso) : ServiceNotification, IRequestHandler<CursoExcluirRequest, CommandResponse<CursoExcluirResponse>>
{
    public async Task<CommandResponse<CursoExcluirResponse>> Handle(CursoExcluirRequest request,
        CancellationToken cancellationToken)
    {
        var curso = await repositoryCurso.GetByAsync(
            tracking: true, 
            p => p.Id == request.Id, 
            cancellationToken: cancellationToken);

        if (curso is null)
        {
            AddNotification("CursoExcluirHandler", "Curso não encontrado.");
            return new CommandResponse<CursoExcluirResponse>(this);
        }

        repositoryCurso.Delete(curso);

        return new CommandResponse<CursoExcluirResponse>(new CursoExcluirResponse(curso.Id, "Curso excluído com sucesso!"), this);
    }
}
