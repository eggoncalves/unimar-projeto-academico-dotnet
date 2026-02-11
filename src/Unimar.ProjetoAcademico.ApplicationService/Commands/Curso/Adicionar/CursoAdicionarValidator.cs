using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Unimar.ProjetoAcademico.ApplicationService.Commands.Curso.Adicionar
{
    public class CursoAdicionarValidator : AbstractValidator<CursoAdicionarRequest>
    {
        public CursoAdicionarValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull().WithMessage("O nome do curso é obrigatório.")
                .NotEmpty().WithMessage("O nome do curso é obrigatório.")
                .MaximumLength(200).WithMessage("O nome do curso deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Periodo)
                .IsInEnum().WithMessage("O período informado é inválido.")
                .NotEmpty().WithMessage("O período é obrigatório.");

            RuleFor(x => x.Descricao)
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");

            RuleFor(x => x.CargaHoraria)
                .NotEmpty().WithMessage("A carga horária é obrigatória.");

            RuleFor(x => x.QuantidadeMaximaAlunos)
                .NotEmpty().WithMessage("A quantidade máxima de alunos é obrigatória.");
        }
    }
}
