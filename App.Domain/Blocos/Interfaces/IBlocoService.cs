using System;
using System.Threading.Tasks;

namespace App.Domain.Blocos.Interfaces
{
    public interface IBlocoService
    {
        Task<bool> ExisteBloco(Guid id);
    }
}