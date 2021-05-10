using System;
using System.Collections.Generic;
using App.Application.Condominios.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Condominios.Queries
{
    public class ObterCondominiosQuery: Query<List<CondominioViewModel>>
    {
        public string Frase { get; set; }
        public ObterCondominiosQuery(string frase)
        {
            Frase = frase;
        }
    }
}