using System;
using App.Application.Pessoas.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Pessoas.Commands
{
    public class AtualizarPessoaCommand: Command<PessoaViewModel>
    {
        public AtualizarPessoaCommand()
        {
        }

        public Guid Id { get; private set; }
        
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public void AtribuirPessoaId(Guid id)
        {
            Id = id;
        }
    }
}