using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Atualizar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Listar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.UoW;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.AppService
{
    public class AppServiceCurso(IMediator mediator, IUnitOfWork unitOfWork) : ServiceNotification, IAppServiceCurso
    {
        public async Task<CommandResponse<CursoObterResponse>> Obter(CursoObterRequest request)
        {
            var commandResponse = await mediator.Send(request);
            AddNotifications(commandResponse.Notificacoes);
            return commandResponse;
        }

        public async Task<CommandResponse<List<CursoListarResponse>>> Listar(CursoListarRequest request)
        {
            var commandResponse = await mediator.Send(request);
            AddNotifications(commandResponse.Notificacoes);
            return commandResponse;
        }

        public async Task<CommandResponse<CursoAdicionarResponse>> Adicionar(CursoAdicionarRequest request)
        {
            var commandResponse = await mediator.Send(request);
            AddNotifications(commandResponse.Notificacoes);

            if (IsValid())
            {
                await unitOfWork.CommitAsync();
                AddNotifications(unitOfWork.ServiceNotifications);

                if (IsInvalid())
                    return new CommandResponse<CursoAdicionarResponse>(this);
            }

            return commandResponse;
        }

        public async Task<CommandResponse<CursoAtualizarResponse>> Atualizar(CursoAtualizarRequest request)
        {
            var commandResponse = await mediator.Send(request);
            AddNotifications(commandResponse.Notificacoes);

            if (IsValid())
            {
                await unitOfWork.CommitAsync();
                AddNotifications(unitOfWork.ServiceNotifications);

                if (IsInvalid())
                    return new CommandResponse<CursoAtualizarResponse>(this);
            }

            return commandResponse;
        }

        public async Task<CommandResponse<CursoExcluirResponse>> Excluir(CursoExcluirRequest request)
        {
            var commandResponse = await mediator.Send(request);
            AddNotifications(commandResponse.Notificacoes);

            if (IsValid())
            {
                await unitOfWork.CommitAsync();
                AddNotifications(unitOfWork.ServiceNotifications);

                if (IsInvalid())
                    return new CommandResponse<CursoExcluirResponse>(this);
            }

            return commandResponse;
        }
    }
}
