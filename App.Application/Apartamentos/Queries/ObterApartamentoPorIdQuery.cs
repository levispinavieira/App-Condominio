using System;
using App.Application.Apartamentos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Apartamentos.Queries
{
    public class ObterApartamentoPorIdQuery: Query<ApartamentoViewModel>
    {
        public Guid Id { get; set; }
        
        public ObterApartamentoPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}