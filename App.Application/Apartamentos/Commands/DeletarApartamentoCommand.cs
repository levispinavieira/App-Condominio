using System;
using App.Infra.Bus.Models;

namespace App.Application.Apartamentos.Commands
{
    public class DeletarApartamentoCommand: Command<bool>
    {
        public DeletarApartamentoCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}