using System;
using System.Threading.Tasks;
using App.Domain.Condominios.Interfaces;
using App.Infra.Data.Uow;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Condominios.Services
{
    public class CondominioService : ICondominioService
    {
        private readonly IUnitOfWork _uow;

        public CondominioService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> ExisteCondominio(Guid id)
        {
            return await _uow.Condominios.ObterTodos().AnyAsync(x => x.Id == id);
        }
    }
}