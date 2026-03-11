using Microsoft.AspNetCore.Mvc;
using Unimar.ProjetoAcademico.Api.Controllers.Base;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Adicionar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Atualizar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Excluir;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Listar;
using Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Obter;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;
using Unimar.ProjetoAcademico.ApplicationService.Interfaces.Services;

namespace Unimar.ProjetoAcademico.Api.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class AlunoFbController(IAppServiceAlunoFb appServiceAlunoFb) : UnimarControllerBase
{
    [HttpGet("obter")] 
    [ProducesResponseType(typeof(CommandResponse<AlunoObterResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Obter([FromQuery] string id)
    {
        var commandResponse = await appServiceAlunoFb.Obter(new AlunoObterRequest(id));
        return RespostaCustomizada(commandResponse);
    }

    [HttpGet("listar")]
    [ProducesResponseType(typeof(CommandResponse<IEnumerable<AlunoListarResponse>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar()
    {
        var commandResponse = await appServiceAlunoFb.Listar(new AlunoListarRequest());
        return RespostaCustomizada(commandResponse);
    }

    [HttpPost("adicionar")]
    [ProducesResponseType(typeof(CommandResponse<AlunoAdicionarResponse>), StatusCodes.Status201Created)]
    public async Task<IActionResult> Adicionar(AlunoAdicionarRequest request)
    {
        var commandResponse = await appServiceAlunoFb.Adicionar(request);
        return RespostaCustomizada(commandResponse);
    }

    [HttpPut("atualizar")]
    [ProducesResponseType(typeof(CommandResponse<AlunoAtualizarResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Atualizar(AlunoAtualizarRequest request)
    {
        var commandResponse = await appServiceAlunoFb.Atualizar(request);
        return RespostaCustomizada(commandResponse);
    }

    [HttpDelete("excluir")]
    [ProducesResponseType(typeof(CommandResponse<AlunoExcluirResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Excluir([FromQuery] string id)
    {
        var commandResponse = await appServiceAlunoFb.Excluir(new AlunoExcluirRequest(id));
        return RespostaCustomizada(commandResponse);
    }
}
