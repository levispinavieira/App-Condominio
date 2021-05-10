using System;
using App.Application.Blocos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Blocos.Queries
{
    public class ObterBlocoPorIdQuery: Query<BlocoViewModel>
    {
        public Guid Id { get; set; }
        
        public ObterBlocoPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}