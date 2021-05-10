using System;
using App.Application.Abstractions;

namespace App.Application.Blocos.ViewModels
{
    public class BlocoViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public Guid CondominioId { get; set; }
    }
}