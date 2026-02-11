using Mapster;
using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Listar;

public class CursoListarHandler(
    IRepositoryCurso repositoryCurso) : ServiceNotification, IRequestHandler<CursoListarRequest, CommandResponse<List<CursoListarResponse>>>
{
    public async Task<CommandResponse<List<CursoListarResponse>>> Handle(CursoListarRequest request, CancellationToken cancellationToken)
    {
        var cursos = await repositoryCurso.ListAsync(
            cancellationToken: cancellationToken);

        var cursosResponse = cursos.Adapt<List<CursoListarResponse>>();

        return new CommandResponse<List<CursoListarResponse>>(cursosResponse, this);
    }
}
