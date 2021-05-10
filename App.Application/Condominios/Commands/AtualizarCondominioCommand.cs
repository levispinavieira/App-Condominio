using System;
using App.Application.Condominios.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Condominios.Commands
{
    public class AtualizarCondominioCommand: Command<CondominioViewModel>
    {
        public AtualizarCondominioCommand()
        {
        }

        public Guid Id { get; private set; }
        
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string EmailSindico { get; set; }

        public void AtribuirCondominioId(Guid id)
        {
            Id = id;
        }
    }
}