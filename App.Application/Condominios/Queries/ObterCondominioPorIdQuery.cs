using System;
using App.Application.Condominios.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Condominios.Queries
{
    public class ObterCondominioPorIdQuery: Query<CondominioViewModel>
    {
        public Guid Id { get; set; }
        public ObterCondominioPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}