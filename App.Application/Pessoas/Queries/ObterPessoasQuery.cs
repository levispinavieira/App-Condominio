using System.Collections.Generic;
using App.Application.Pessoas.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Pessoas.Queries
{
    public class ObterPessoasQuery: Query<List<PessoaViewModel>>
    {
        public string Frase { get; set; }
        public ObterPessoasQuery(string frase)
        {
            Frase = frase;
        }
    }
}