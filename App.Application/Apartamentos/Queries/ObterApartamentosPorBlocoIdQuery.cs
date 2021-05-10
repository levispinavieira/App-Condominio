using System;
using System.Collections.Generic;
using App.Application.Apartamentos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Apartamentos.Queries
{
    public class ObterApartamentosPorBlocoIdQuery: Query<List<ApartamentoViewModel>>
    {
        public Guid Id { get; set; }
        public ObterApartamentosPorBlocoIdQuery(Guid id)
        {
            Id = id;
        }
    }
}