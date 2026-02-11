using Microsoft.AspNetCore.Mvc;
using Unimar.ProjetoAcademico.Api.Controllers.Base;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Atualizar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Listar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;

namespace Unimar.ProjetoAcademico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController(IAppServiceCurso appServiceCurso) : UnimarControllerBase
    {
        [HttpGet("obter/{id:guid}")]
        [ProducesResponseType(typeof(CommandResponse<CursoObterResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Obter(Guid id)
        {
            var commandResponse = await appServiceCurso.Obter(new CursoObterRequest(id));
            return RespostaCustomizada(commandResponse);
        }

        [HttpGet("listar")]
        [ProducesResponseType(typeof(CommandResponse<IEnumerable<CursoListarResponse>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar()
        {
            var commandResponse = await appServiceCurso.Listar(new CursoListarRequest());
            return RespostaCustomizada(commandResponse);
        }

        [HttpPost("adicionar")]
        [ProducesResponseType(typeof(CommandResponse<CursoAdicionarResponse>), StatusCodes.Status201Created)]
        public async Task<IActionResult> Adicionar(CursoAdicionarRequest request)
        {
            var commandResponse = await appServiceCurso.Adicionar(request);
            return RespostaCustomizada(commandResponse);
        }

        [HttpPut("atualizar")]
        [ProducesResponseType(typeof(CommandResponse<CursoAtualizarResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Adicionar(CursoAtualizarRequest request)
        {
            var commandResponse = await appServiceCurso.Atualizar(request);
            return RespostaCustomizada(commandResponse);
        }

        [HttpDelete("excluir/{id:guid}")]
        [ProducesResponseType(typeof(CommandResponse<CursoExcluirResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var commandResponse = await appServiceCurso.Excluir(new CursoExcluirRequest(id));
            return RespostaCustomizada(commandResponse);
        }
    }
}
