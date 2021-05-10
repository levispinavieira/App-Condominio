using System;
using App.Application.Pessoas.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Pessoas.Commands
{
    public class CadastrarPessoaCommand: Command<PessoaViewModel>
    {
        public CadastrarPessoaCommand()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public Guid ApartamentoId { get; private set; }

        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        
        public void AtribuirApartamentoId(Guid apartamentoId)
        {
            ApartamentoId = apartamentoId;
        }

    }
}