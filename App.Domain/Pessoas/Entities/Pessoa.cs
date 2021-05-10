using System;
using System.Collections.Generic;
using App.Domain.Abstractions.Entities;
using App.Domain.Apartamentos.Entities;
using App.Domain.Pessoas.Validators;
using FluentValidation;

namespace App.Domain.Pessoas.Entities
{
    public class Pessoa : ValidatableEntity<Pessoa>
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public Guid ApartamentoId { get; set; }

        public Pessoa(Guid id, string nomeCompleto, DateTime dataNascimento, string telefone, string cpf, string email, Guid apartamentoId) : base(id)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Cpf = cpf;
            Email = email;
            ApartamentoId = apartamentoId;
        }

        public virtual Apartamento Apartamento { get; set; }

        protected override AbstractValidator<Pessoa> GetValidator()
        {
            return new PessoaValidator();
        }
    }
}