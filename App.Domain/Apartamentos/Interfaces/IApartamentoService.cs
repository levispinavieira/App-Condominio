using System;
using System.Threading.Tasks;

namespace App.Domain.Apartamentos.Interfaces
{
    public interface IApartamentoService
    {
        Task<bool> ExisteApartamento(Guid id);
    }
}