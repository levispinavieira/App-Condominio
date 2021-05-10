using System;
using System.Collections.Generic;
using App.Domain.Abstractions.Entities;
using App.Domain.Apartamentos.Entities;
using App.Domain.Blocos.Validators;
using App.Domain.Condominios.Entities;
using FluentValidation;

namespace App.Domain.Blocos.Entities
{
    public class Bloco : ValidatableEntity<Bloco>
    {
        public string Nome { get; set; }
        public Guid CondominioId { get; set; }

        public Bloco(Guid id, string nome, Guid condominioId) : base(id)
        {
            Nome = nome;
            CondominioId = condominioId;
        }
        
        public virtual Condominio Condominio{ get; set; }
        
        public virtual ICollection<Apartamento> Apartamentos { get; set; }

        protected override AbstractValidator<Bloco> GetValidator()
        {
            return new BlocoValidator();
        }
    }
}