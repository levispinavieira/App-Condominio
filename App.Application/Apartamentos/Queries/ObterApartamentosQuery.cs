using System.Collections.Generic;
using App.Application.Apartamentos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Apartamentos.Queries
{
    public class ObterApartamentosQuery: Query<List<ApartamentoViewModel>>
    {
        public ObterApartamentosQuery()
        {
        }
    }
}