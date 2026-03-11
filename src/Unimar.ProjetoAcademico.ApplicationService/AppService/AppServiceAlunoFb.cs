using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Adicionar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Atualizar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Excluir;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Listar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Obter;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.AppService;

public class AppServiceAlunoFb(
    IMediator mediator) : ServiceNotification, IAppServiceAlunoFb
{
    public async Task<CommandResponse<AlunoObterResponse>> Obter(AlunoObterRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);
        return commandResponse;
    }

    public Task<CommandResponse<AlunoObterResponse>> ObterPorNome(AlunoObterRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<CommandResponse<List<AlunoListarResponse>>> Listar(AlunoListarRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);
        return commandResponse;
    }

    public async Task<CommandResponse<AlunoAdicionarResponse>> Adicionar(AlunoAdicionarRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        return IsInvalid() 
            ? new CommandResponse<AlunoAdicionarResponse>(this) 
            : commandResponse;
    }

    public async Task<CommandResponse<AlunoAtualizarResponse>> Atualizar(AlunoAtualizarRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        return IsInvalid() 
            ? new CommandResponse<AlunoAtualizarResponse>(this) 
            : commandResponse;
    }

    public async Task<CommandResponse<AlunoExcluirResponse>> Excluir(AlunoExcluirRequest request)
    {
        var commandResponse = await mediator.Send(request);
        AddNotifications(commandResponse.Notificacoes);

        return IsInvalid() 
            ? new CommandResponse<AlunoExcluirResponse>(this) 
            : commandResponse;
    }
}
