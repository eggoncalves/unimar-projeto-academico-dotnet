using FluentValidation;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Excluir;

public class CursoExcluirValidator : AbstractValidator<CursoExcluirRequest>
{
    public CursoExcluirValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("O ID do curso é obrigatório.")
            .NotEmpty().WithMessage("O ID do curso é obrigatório.");
    }
}