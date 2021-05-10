using System;
using App.Infra.Bus.Models;

namespace App.Application.Condominios.Commands
{
    public class DeletarCondominioCommand: Command<bool>
    {
        public DeletarCondominioCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}