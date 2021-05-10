using System;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Abstractions.Entities;
using App.Domain.Abstractions.Interfaces;
using App.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repositorys
{
    public abstract class Repository<TEntity> : Repository<IDbAppContext, TEntity> where TEntity : Entity
    {
        protected Repository(Lazy<IDbAppContext> context) : base(context)
        {
        }
    }

    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TEntity : Entity
        where TContext : IDbAppContext
    {
        private readonly Lazy<TContext> DbWrite;

        protected TContext Db => DbWrite.Value;

        protected DbSet<TEntity> DbSet => Db.Set<TEntity>();

        protected Repository(Lazy<TContext> context)
        {
            DbWrite = context;
        }

        public virtual IQueryable<TEntity> ObterTodos()
        {
            return DbSet;
        }
        
        public virtual async Task Adicionar(TEntity obj)
            => await Db
                .Set<TEntity>()
                .AddAsync(obj);
        
        public virtual void Atualizar(TEntity obj)
            => Db
                .Set<TEntity>()
                .Update(obj);
        

        public virtual async Task<TEntity> ObterPorId(Guid id)
            => await DbSet
                .FirstOrDefaultAsync(e => e.Id == id);

        public virtual void Remover(TEntity entity, bool destroy = false)
        {
            if (destroy)
            {
                DbSet.Remove(entity);
                return;
            }

            entity.DeletadoEm = DateTime.UtcNow;
            entity.Ativo = false;

            Db
                .Set<TEntity>()
                .Update(entity);
        }

        public void Dispose()
            => Db?.Dispose();
    }
}