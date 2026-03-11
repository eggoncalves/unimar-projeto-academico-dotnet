using Mapster;
using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Listar;

public class AlunoListarHandler(
    IRepositoryAlunoFb repositoryAlunoFb) : ServiceNotification, IRequestHandler<AlunoListarRequest, CommandResponse<List<AlunoListarResponse>>>
{
    public async Task<CommandResponse<List<AlunoListarResponse>>> Handle(AlunoListarRequest request, CancellationToken cancellationToken)
    {
        var alunosFb = await repositoryAlunoFb.ListAsync();
        return new CommandResponse<List<AlunoListarResponse>>(alunosFb.Adapt<List<AlunoListarResponse>>(), this);
    }
}
