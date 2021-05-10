using System;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Apartamentos.Interfaces;
using App.Domain.Blocos.Interfaces;
using App.Domain.Condominios.Interfaces;
using App.Domain.Pessoas.Interfaces;

namespace App.Infra.Data.Uow
{
    public interface IUnitOfWork: IDisposable
    {
        IPessoaRepository Pessoas { get; }
        IApartamentoRepository Apartamentos { get; }
        ICondominioRepository Condominios { get; }
        IBlocoRepository Blocos { get; }

        Task<bool> Commit(CancellationToken cancellationToken = default);
    }
}