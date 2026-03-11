using Mapster;
using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Adicionar;

public class AlunoAdicionarHandler(
    IRepositoryAlunoFb repositoryAlunoFb) : ServiceNotification, IRequestHandler<AlunoAdicionarRequest, CommandResponse<AlunoAdicionarResponse>>
{
    public async Task<CommandResponse<AlunoAdicionarResponse>> Handle(AlunoAdicionarRequest request, CancellationToken cancellationToken)
    {
        var alunoFb = request.Adapt<Domain.Entities.AlunoFb>();

        var id = await repositoryAlunoFb.AddAsync(alunoFb);

        return new CommandResponse<AlunoAdicionarResponse>(new AlunoAdicionarResponse(id, "Aluno adicionado com sucesso!"), this);
    }
}
