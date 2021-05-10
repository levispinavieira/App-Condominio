using App.Domain.Blocos.Entities;
using App.Shared.Utils;
using FluentValidation;

namespace App.Domain.Blocos.Validators
{
    public class BlocoValidator: AbstractValidator<Bloco>
    {
        public BlocoValidator()
        {
            RuleFor(v => v.Nome)
                .Must(ValidationUtils.Preenchido)
                .WithErrorCode(ValidationUtils.OBRIGATORIO);
        }
    }
}