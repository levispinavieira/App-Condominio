using System;
using App.Infra.Bus.Models;

namespace App.Application.Blocos.Commands
{
    public class DeletarBlocoCommand: Command<bool>
    {
        public DeletarBlocoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}