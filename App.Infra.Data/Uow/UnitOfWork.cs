using System;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Apartamentos.Interfaces;
using App.Domain.Blocos.Interfaces;
using App.Domain.Condominios.Interfaces;
using App.Domain.Pessoas.Interfaces;
using App.Infra.Data.Interfaces;
using App.Infra.Data.Repositorys;

namespace App.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPessoaRepository _pessoas;
        private IApartamentoRepository _apartamentos;
        private ICondominioRepository _condominios;
        private IBlocoRepository _blocos;

        public UnitOfWork(Lazy<IDbAppContext> tenantDbcContext)
        {
            DbContextWrite = tenantDbcContext;
        }
        
        public IPessoaRepository Pessoas => _pessoas ??= new PessoaRepository(DbContextWrite);
        public IApartamentoRepository Apartamentos => _apartamentos ??= new ApartamentoRepository(DbContextWrite);
        public ICondominioRepository Condominios => _condominios ??= new CondominioRepository(DbContextWrite);
        public IBlocoRepository Blocos => _blocos ??= new BlocoRepository(DbContextWrite);

        private Lazy<IDbAppContext> DbContextWrite { get; }
        
        public IDbAppContext DbContext => DbContextWrite.Value;
        
        public async Task<bool> Commit(CancellationToken cancellationToken = default)
        {
            if (!DbContext.HasChanges) return true;

            var success = await DbContext.SaveChangesAsync(cancellationToken) > 0;

            return success;
        }
        
        public void Dispose()
        {
            /*if (DbContextWrite.IsValueCreated)
            {
                DbContextWrite.Value.Dispose();
            }*/
        }
    }
}