using System;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Blocos.Entities;
using App.Domain.Blocos.Interfaces;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repositorys
{
    public class BlocoRepository: Repository<Bloco>, IBlocoRepository
    {
        public BlocoRepository(Lazy<IDbAppContext> context) : base(context)
        {
        }

        public IQueryable<Bloco> ObterBlocosPorCondominioId(Guid id, string frase)
        {
            var query = DbSet.Where(x => x.CondominioId == id);

            if (!string.IsNullOrEmpty(frase))
            {
                query = query.Where(x => x.Nome.Contains(frase));
            }

            return query;
        }
        
        public IQueryable<Bloco> ObterBlocos(string frase)
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