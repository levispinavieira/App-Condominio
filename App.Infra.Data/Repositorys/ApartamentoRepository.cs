using System;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Apartamentos.Entities;
using App.Domain.Apartamentos.Interfaces;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repositorys
{
    public class ApartamentoRepository: Repository<Apartamento>, IApartamentoRepository
    {
        public ApartamentoRepository(Lazy<IDbAppContext> context) : base(context)
        {
        }

        public IQueryable<Apartamento> ObterApartamentosPorBlocoId(Guid id)
        {
            return DbSet.Where(x => x.BlocoId == id);
        }
        
        public IQueryable<Apartamento> ObterApartamentos()
        {
            return DbSet.AsQueryable();
        }
        
    }
}