using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Excluir;

public class AlunoExcluirHandler(
    IRepositoryAlunoFb repositoryAlunoFb) : ServiceNotification, IRequestHandler<AlunoExcluirRequest, CommandResponse<AlunoExcluirResponse>>
{
    public async Task<CommandResponse<AlunoExcluirResponse>> Handle(AlunoExcluirRequest request,
        CancellationToken cancellationToken)
    {
        var alunoFb = await repositoryAlunoFb.GetByIdAsync(request.Id);
        if (alunoFb is null)
        {
            AddNotification("AlunoExcluirHandler", "Aluno não encontrado.");
            return new CommandResponse<AlunoExcluirResponse>(this);
        }

        await repositoryAlunoFb.DeleteAsync(alunoFb.Id);

        return new CommandResponse<AlunoExcluirResponse>(new AlunoExcluirResponse(alunoFb.Id, "Aluno excluído com sucesso!"), this);
    }
}
