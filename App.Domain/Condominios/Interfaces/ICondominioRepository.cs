using System.Linq;
using App.Domain.Abstractions.Interfaces;
using App.Domain.Condominios.Entities;

namespace App.Domain.Condominios.Interfaces
{
    public interface ICondominioRepository: IRepository<Condominio>
    {
        IQueryable<Condominio> ObterCondominios(string frase);
    }
}