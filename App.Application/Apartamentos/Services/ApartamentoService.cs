using System;
using System.Threading.Tasks;
using App.Domain.Apartamentos.Interfaces;
using App.Infra.Data.Uow;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Apartamentos.Services
{
    public class ApartamentoService : IApartamentoService
    {
        private readonly IUnitOfWork _uow;

        public ApartamentoService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> ExisteApartamento(Guid id)
        {
            return await _uow.Apartamentos.ObterTodos().AnyAsync(x => x.Id == id);
        }
    }
}