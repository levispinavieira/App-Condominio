using System;
using System.Collections.Generic;
using App.Application.Blocos.ViewModels;
using App.Infra.Bus.Models;

namespace App.Application.Blocos.Queries
{
    public class ObterBlocosPorCondominioIdQuery: Query<List<BlocoViewModel>>
    {
        public Guid Id { get; set; }
        public string Frase { get; set; }
        public ObterBlocosPorCondominioIdQuery(Guid id, string frase)
        {
            Id = id;
            Frase = frase;
        }
    }
}