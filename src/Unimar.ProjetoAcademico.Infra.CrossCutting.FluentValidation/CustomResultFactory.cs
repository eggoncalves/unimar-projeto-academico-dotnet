using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace Unimar.ProjetoAcademico.Infra.CrossCutting.FluentValidation;

public class CustomResultFactory : ServiceNotification.ServiceNotification, IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(ActionExecutingContext ctx, ValidationProblemDetails? vpd)
    {
        if (vpd?.Errors is { Count: > 0 })
        {
            foreach (var (field, messages) in vpd.Errors)
            {
                foreach (var message in messages)
                {
                    AddNotification(field, message);
                }
            }
        }

        return new BadRequestObjectResult(new
        {
            Sucesso = false,
            Notificacoes = Notifications
        });
    }
}