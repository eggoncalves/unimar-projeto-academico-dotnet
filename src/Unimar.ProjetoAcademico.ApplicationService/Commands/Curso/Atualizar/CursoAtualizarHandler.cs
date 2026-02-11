using Mapster;
using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Atualizar;

public class CursoAtualizarHandler(
    IRepositoryCurso repositoryCurso) : ServiceNotification, IRequestHandler<CursoAtualizarRequest, CommandResponse<CursoAtualizarResponse>>
{
    public async Task<CommandResponse<CursoAtualizarResponse>> Handle(CursoAtualizarRequest request, CancellationToken cancellationToken)
    {
        var curso = await repositoryCurso.GetByAsync(
            tracking: true, 
            p => p.Id == request.Id, 
            cancellationToken: cancellationToken);

        if (curso is null)
        {
            AddNotification("CursoAtualizarHandler", "Curso não encontrado.");
            return new CommandResponse<CursoAtualizarResponse>(this);
        }

        request.Adapt(curso);

        repositoryCurso.Update(curso);

        return new CommandResponse<CursoAtualizarResponse>(new CursoAtualizarResponse(curso.Id, "Curso atualizado com sucesso!"), this);
    }
}
