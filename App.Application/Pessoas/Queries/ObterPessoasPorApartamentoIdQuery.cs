using System;
using System.Collections.Generic;
using App.Application.Pessoas.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Pessoas.Queries
{
    public class ObterPessoasPorApartamentoIdQuery: Query<List<PessoaViewModel>>
    {
        public Guid Id { get; set; }

        public string Frase { get; set; }

        public ObterPessoasPorApartamentoIdQuery(Guid id, string frase)
        {
            Id = id;
            Frase = frase;
        }
    }
}