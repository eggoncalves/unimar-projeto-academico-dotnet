using Mapster;
using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Atualizar;

public class AlunoAtualizarHandler(
    IRepositoryAlunoFb repositoryAlunoFb) : ServiceNotification, IRequestHandler<AlunoAtualizarRequest, CommandResponse<AlunoAtualizarResponse>>
{
    public async Task<CommandResponse<AlunoAtualizarResponse>> Handle(AlunoAtualizarRequest request, CancellationToken cancellationToken)
    {
        var alunoFb = await repositoryAlunoFb.GetByIdAsync(request.Id.ToString());
        if (alunoFb is null)
        {
            AddNotification("AlunoAtualizarHandler", "Aluno não encontrado.");
            return new CommandResponse<AlunoAtualizarResponse>(this);
        }

        request.Adapt(alunoFb);

        await repositoryAlunoFb.UpdateAsync(alunoFb.Id, alunoFb);

        return new CommandResponse<AlunoAtualizarResponse>(new AlunoAtualizarResponse(alunoFb.Id, "Aluno atualizado com sucesso!"), this);
    }
}
