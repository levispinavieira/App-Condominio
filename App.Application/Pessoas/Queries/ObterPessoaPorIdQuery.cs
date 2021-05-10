using System;
using App.Application.Pessoas.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Pessoas.Queries
{
    public class ObterPessoaPorIdQuery: Query<PessoaViewModel>
    {
        public Guid Id { get; set; }
        
        public ObterPessoaPorIdQuery(Guid id)
        {
            Id = id;
        }
    }
}