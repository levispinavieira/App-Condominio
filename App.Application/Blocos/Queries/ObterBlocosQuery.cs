using System.Collections.Generic;
using App.Application.Blocos.ViewModels;
using App.Application.Condominios.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Blocos.Queries
{
    public class ObterBlocosQuery: Query<List<BlocoViewModel>>
    {
        public string Frase { get; set; }
        public ObterBlocosQuery(string frase)
        {
            Frase = frase;
        }
    }
}