using System;
using App.Application.Blocos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Blocos.Commands
{
    public class CadastrarBlocoCommand: Command<BlocoViewModel>
    {
        public CadastrarBlocoCommand()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        
        public Guid CondominioId { get; private set; }

        public string Nome { get; set; }

        public void AtribuirCondominioId(Guid condominioId)
        {
            CondominioId = condominioId;
        }
    }
}