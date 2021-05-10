using System;
using System.Linq;
using App.Domain.Condominios.Entities;
using App.Domain.Condominios.Interfaces;
using App.Infra.Data.Interfaces;

namespace App.Infra.Data.Repositorys
{
    public class CondominioRepository: Repository<Condominio>, ICondominioRepository
    {
        public CondominioRepository(Lazy<IDbAppContext> context) : base(context)
        {
        }

        public IQueryable<Condominio> ObterCondominios(string frase)
        {
            var query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(frase))
            {
                query = query.Where(x => x.Nome.Contains(frase));
            }

            return query;
        }
        
    }
}