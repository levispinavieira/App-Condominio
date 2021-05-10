using System;
using System.Collections.Generic;
using App.Domain.Abstractions.Entities;
using App.Domain.Blocos.Entities;
using App.Domain.Condominios.Validators;
using FluentValidation;

namespace App.Domain.Condominios.Entities
{
    public class Condominio : ValidatableEntity<Condominio>
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailSindico { get; set; }

        public Condominio(Guid id, string nome, string telefone, string emailSindico) : base(id)
        {
            Nome = nome;
            Telefone = telefone;
            EmailSindico = emailSindico;
            Ativo = true;
        }
        
        public virtual ICollection<Bloco> Blocos { get; set; }
        
        protected override AbstractValidator<Condominio> GetValidator()
        {
            return new CondominioValidator();
        }
    }
}