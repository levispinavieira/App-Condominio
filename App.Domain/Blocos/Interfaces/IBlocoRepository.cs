using System;
using System.Linq;
using App.Domain.Abstractions.Interfaces;
using App.Domain.Blocos.Entities;

namespace App.Domain.Blocos.Interfaces
{
    public interface IBlocoRepository: IRepository<Bloco>
    {
        IQueryable<Bloco> ObterBlocosPorCondominioId(Guid id, string frase);
        IQueryable<Bloco> ObterBlocos(string frase);
    }
}