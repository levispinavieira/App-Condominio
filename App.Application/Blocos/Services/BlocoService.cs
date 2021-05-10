using System;
using System.Threading.Tasks;
using App.Domain.Blocos.Interfaces;
using App.Infra.Data.Uow;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Blocos.Services
{
    public class BlocoService: IBlocoService
    {
        private readonly IUnitOfWork _uow;

        public BlocoService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task<bool> ExisteBloco(Guid id)
        {
            return await _uow.Blocos.ObterTodos().AnyAsync(x => x.Id == id);
        }
    }
}