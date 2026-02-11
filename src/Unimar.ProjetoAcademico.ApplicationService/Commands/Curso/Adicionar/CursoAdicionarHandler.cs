using NetDevPack.SimpleMediator;
using Mapster;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.Domain.Interfaces.Repositories;
using Unimar.ProjetoAcademico.Infra.CrossCutting.ServiceNotification;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar
{
    public class CursoAdicionarHandler(IRepositoryCurso repositoryCurso) : ServiceNotification, IRequestHandler<CursoAdicionarRequest, CommandResponse<CursoAdicionarResponse>>
    {
        public async Task<CommandResponse<CursoAdicionarResponse>> Handle(CursoAdicionarRequest request, CancellationToken cancellationToken)
        {
            var curso = request.Adapt<Domain.Entities.Curso>();

            if (curso is null)
            {
                AddNotification("CursoAdicionarHandler", "Curso não pode ser nulo.");
                return new CommandResponse<CursoAdicionarResponse>(this);
            }
                
            await repositoryCurso.AddAsync(curso, cancellationToken);
            return new CommandResponse<CursoAdicionarResponse>(new CursoAdicionarResponse(curso.Id, "Curso adicionado com sucesso!"), this);
        }
    }
}
