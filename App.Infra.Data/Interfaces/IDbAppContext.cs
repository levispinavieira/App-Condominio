using System;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Apartamentos.Entities;
using App.Domain.Blocos.Entities;
using App.Domain.Condominios.Entities;
using App.Domain.Pessoas.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Interfaces
{
    public interface IDbAppContext : IDisposable
    {
        bool HasChanges { get; }
        
        DbSet<Pessoa> Pessoas { get; set; }
        DbSet<Condominio> Condominios { get; set; }
        DbSet<Bloco> Blocos { get; set; }
        DbSet<Apartamento> Apartamentos { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}