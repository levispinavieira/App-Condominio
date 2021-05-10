using System;
using App.Application.Abstractions;

namespace App.Application.Apartamentos.ViewModels
{
    public class ApartamentoViewModel : BaseViewModel
    {
        public int Numero { get; set; }
        public int Andar { get; set; }
        public Guid BlocoId { get; set; }
    }
}