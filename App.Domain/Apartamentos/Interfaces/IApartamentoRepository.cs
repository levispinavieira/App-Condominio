using System;
using System.Linq;
using App.Domain.Abstractions.Interfaces;
using App.Domain.Apartamentos.Entities;

namespace App.Domain.Apartamentos.Interfaces
{
    public interface IApartamentoRepository: IRepository<Apartamento>
    {
        IQueryable<Apartamento> ObterApartamentosPorBlocoId(Guid id);
        IQueryable<Apartamento> ObterApartamentos();
    }
}