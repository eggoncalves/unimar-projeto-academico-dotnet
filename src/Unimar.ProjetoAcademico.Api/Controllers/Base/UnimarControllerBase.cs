using Microsoft.AspNetCore.Mvc;
using Unimar.ProjetoAcademico.ApplicationService.DTOs;

namespace Unimar.ProjetoAcademico.Api.Controllers.Base;

public abstract class UnimarControllerBase : ControllerBase
{
    protected IActionResult RespostaCustomizada<T>(CommandResponse<T> command)
        where T : class
    {
        if (!command.Sucesso)
            return BadRequest(command);

        return Ok(command);
    }
}
