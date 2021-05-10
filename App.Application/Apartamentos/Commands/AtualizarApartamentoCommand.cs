using System;
using App.Application.Apartamentos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Apartamentos.Commands
{
    public class AtualizarApartamentoCommand: Command<ApartamentoViewModel>
    {
        public AtualizarApartamentoCommand()
        {
        }

        public Guid Id { get; private set; }
        
        public int Numero { get; set; }
        public int Andar { get; set; }


        public void AtribuirApartamentoId(Guid id)
        {
            Id = id;
        }
    }
}