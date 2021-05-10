using System;
using App.Infra.Bus.Models;

namespace App.Application.Pessoas.Commands
{
    public class DeletarPessoaCommand: Command<bool>
    {
        public DeletarPessoaCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}