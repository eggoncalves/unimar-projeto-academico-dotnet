using FluentValidation;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.AlunoFb.Adicionar;

public class AlunoAdicionarValidator : AbstractValidator<AlunoAdicionarRequest>
{
    public AlunoAdicionarValidator()
    {
        RuleFor(x => x.Nome)
            .NotNull().WithMessage("O nome do aluno é obrigatório.")
            .NotEmpty().WithMessage("O nome do aluno é obrigatório.")
            .MaximumLength(200).WithMessage("O nome do aluno deve ter no máximo 200 caracteres.");

        RuleFor(x => x.Email)
            .NotNull().WithMessage("O e-mail é obrigatório.")
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("O e-mail informado é inválido.")
            .MaximumLength(200).WithMessage("O e-mail deve ter no máximo 200 caracteres.");

        RuleFor(x => x.Matricula)
            .NotNull().WithMessage("A matrícula é obrigatória.")
            .NotEmpty().WithMessage("A matrícula é obrigatória.")
            .MaximumLength(50).WithMessage("A matrícula deve ter no máximo 50 caracteres.");
    }
}
