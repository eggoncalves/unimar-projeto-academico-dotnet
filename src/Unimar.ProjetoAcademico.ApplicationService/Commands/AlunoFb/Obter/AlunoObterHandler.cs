using Mapster;
using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Obter;

public class AlunoObterHandler(
    IRepositoryAlunoFb repositoryAlunoFb) : ServiceNotification, IRequestHandler<AlunoObterRequest, CommandResponse<AlunoObterResponse>>
{
    public async Task<CommandResponse<AlunoObterResponse>> Handle(AlunoObterRequest request, CancellationToken cancellationToken)
    {
        var alunoFb = await repositoryAlunoFb.GetByIdAsync(request.Id);
        if (alunoFb is null)
        {
            AddNotification("AlunoObterHandler", "Aluno não encontrado.");
            return new CommandResponse<AlunoObterResponse>(this);
        }

        return new CommandResponse<AlunoObterResponse>(alunoFb.Adapt<AlunoObterResponse>(), this);
    }
}
