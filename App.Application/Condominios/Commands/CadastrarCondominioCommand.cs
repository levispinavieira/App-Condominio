using System;
using App.Application.Condominios.ViewModels;
using App.Infra.Bus.Models;
using MediatR;

namespace App.Application.Condominios.Commands
{
    public class CadastrarCondominioCommand: Command<CondominioViewModel>
    {
        public CadastrarCondominioCommand()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailSindico { get; set; }

    }
}