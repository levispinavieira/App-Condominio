using App.Domain.Condominios.Entities;
using App.Shared.Utils;
using FluentValidation;

namespace App.Domain.Condominios.Validators
{
    public class CondominioValidator: AbstractValidator<Condominio>
    {
        public CondominioValidator()
        {
            RuleFor(v => v.Nome)
                .Must(ValidationUtils.Preenchido)
                .WithErrorCode(ValidationUtils.OBRIGATORIO);
        }
    }
}