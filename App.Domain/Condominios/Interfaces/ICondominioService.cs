using System;
using System.Threading.Tasks;

namespace App.Domain.Condominios.Interfaces
{
    public interface ICondominioService
    {
        Task<bool> ExisteCondominio(Guid id);
    }
}