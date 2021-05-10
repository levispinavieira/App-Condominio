using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Results;

namespace App.Domain.Abstractions.Entities
{
    public abstract class ValidatableEntity<T> : Entity where T : ValidatableEntity<T>
    {
        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        protected ValidatableEntity()
        {
        }

        protected ValidatableEntity(Guid id) : base(id)
        {
        }
        
        public bool EhValido()
        {
            if (ValidationResult == null)
            {
                Validar();
            }

            return ValidationResult == null || ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidationResult = GetValidator()?.Validate((T)this);
        }

        protected abstract AbstractValidator<T> GetValidator();
    }
}