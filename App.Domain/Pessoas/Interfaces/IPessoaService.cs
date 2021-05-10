using System;
using System.Threading.Tasks;

namespace App.Domain.Pessoas.Interfaces
{
    public interface IPessoaService
    {
        Task<bool> ExistePessoa(Guid id);
    }
}