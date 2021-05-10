using System;
using App.Application.Apartamentos.ViewModels;
using App.Infra.Bus.Models;
using MediatR;

namespace App.Application.Apartamentos.Commands
{
    public class CadastrarApartamentoCommand : Command<ApartamentoViewModel>
    {
        public CadastrarApartamentoCommand()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public Guid BlocoId { get; private set; }
        
        public int Numero  { get; set; }
        public int Andar { get; set; }


        public void AtribuirBlocoId(Guid blocoId)
        {
            BlocoId = blocoId;
        }

    }
}