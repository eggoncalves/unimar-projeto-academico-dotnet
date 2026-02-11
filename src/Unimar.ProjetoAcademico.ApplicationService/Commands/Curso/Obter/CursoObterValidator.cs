using FluentValidation;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Obter;

public class CursoObterValidator : AbstractValidator<CursoObterRequest>
{
    public CursoObterValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("O ID do curso é obrigatório.")
            .NotEmpty().WithMessage("O ID do curso é obrigatório.");
    }
}