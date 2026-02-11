using Mapster;
using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;

public class CursoObterHandler(
    IRepositoryCurso repositoryCurso) : ServiceNotification, IRequestHandler<CursoObterRequest, CommandResponse<CursoObterResponse>>
{
    public async Task<CommandResponse<CursoObterResponse>> Handle(CursoObterRequest request, CancellationToken cancellationToken)
    {
        var curso = await repositoryCurso.GetByAsync(request.Id, cancellationToken: cancellationToken);
        if (curso is null)
        {
            AddNotification("CursoObterHandler", "Curso não encontrado.");
            return new CommandResponse<CursoObterResponse>(this);
        }

        return new CommandResponse<CursoObterResponse>(curso.Adapt<CursoObterResponse>(), this);
    }
}
