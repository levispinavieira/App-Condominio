using System;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Pessoas.Entities;
using App.Domain.Pessoas.Interfaces;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repositorys
{
    public class PessoaRepository: Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(Lazy<IDbAppContext> context) : base(context)
        {
        }

        public IQueryable<Pessoa> ObterPessoasPorApartamentoId(Guid id, string frase)
        {
            var query = DbSet.Where(x => x.ApartamentoId == id);

            if (!string.IsNullOrEmpty(frase))
            {
                query = query.Where(x => x.NomeCompleto.Contains(frase));
            }

            return query;
        }

        public IQueryable<Pessoa> ObterPessoas(string frase)
        {
            var query = DbSet.AsQueryable();

            if (!string.IsNullOrEmpty(frase))
            {
                query = query.Where(x => x.NomeCompleto.Contains(frase));
            }

            return query;
        }
        
    }
}