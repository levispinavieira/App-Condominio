using App.Domain.Apartamentos.Entities;
using App.Shared.Utils;
using FluentValidation;

namespace App.Domain.Apartamentos.Validators
{
    public class ApartamentoValidator: AbstractValidator<Apartamento>
    {
        public ApartamentoValidator()
        {
            RuleFor(v => v.Numero)
                .GreaterThan(0)
                .WithErrorCode(ValidationUtils.MAIOR_QUE);
        }
    }
}