using System;
using System.Collections.Generic;
using App.Domain.Abstractions.Entities;
using App.Domain.Apartamentos.Validators;
using App.Domain.Blocos.Entities;
using App.Domain.Pessoas.Entities;
using FluentValidation;

namespace App.Domain.Apartamentos.Entities
{
    public class Apartamento : ValidatableEntity<Apartamento>
    {
        public int Numero { get; set; }
        public int Andar { get; set; }
        public Guid BlocoId { get; set; }

        public Apartamento(Guid id, int numero, int andar, Guid blocoId) : base(id)
        {
            Numero = numero;
            Andar = andar;
            BlocoId = blocoId;
        }

        public virtual Bloco Bloco { get; set; }
        
        public virtual ICollection<Pessoa> Pessoas { get; set; }

        protected override AbstractValidator<Apartamento> GetValidator()
        {
            return new ApartamentoValidator();
        }
    }
}