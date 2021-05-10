using App.Domain.Pessoas.Entities;
using App.Shared.Utils;
using FluentValidation;

namespace App.Domain.Pessoas.Validators
{
    public class PessoaValidator: AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(v => v.NomeCompleto)
                .Must(ValidationUtils.Preenchido)
                .WithErrorCode(ValidationUtils.OBRIGATORIO);
        }
    }
}