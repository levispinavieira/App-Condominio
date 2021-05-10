using System;
using System.Threading.Tasks;
using App.Domain.Pessoas.Interfaces;
using App.Infra.Data.Uow;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Pessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IUnitOfWork _uow;

        public PessoaService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task<bool> ExistePessoa(Guid id)
        {
            return await _uow.Pessoas.ObterTodos().AnyAsync(x => x.Id == id);
        }
    }
}