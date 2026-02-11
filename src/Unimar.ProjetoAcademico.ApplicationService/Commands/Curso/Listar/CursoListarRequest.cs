using NetDevPack.SimpleMediator;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Listar;

public class CursoListarRequest : IRequest<CommandResponse<List<CursoListarResponse>>>;