using System;
using App.Application.Blocos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Blocos.Commands
{
    public class AtualizarBlocoCommand: Command<BlocoViewModel>
    {
        public AtualizarBlocoCommand()
        {
        }

        public Guid Id { get; private set; }
        
        public string Nome { get; set; }

        public void AtribuirBlocoId(Guid id)
        {
            Id = id;
        }
    }
}