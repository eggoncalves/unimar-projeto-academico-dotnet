using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Listar;

public class AlunoListarRequest : IRequest<CommandResponse<List<AlunoListarResponse>>>;
