using System;
using System.Linq;
using App.Domain.Abstractions.Interfaces;
using App.Domain.Pessoas.Entities;

namespace App.Domain.Pessoas.Interfaces
{
    public interface IPessoaRepository: IRepository<Pessoa>
    {
        IQueryable<Pessoa> ObterPessoasPorApartamentoId(Guid id, string frase);
        IQueryable<Pessoa> ObterPessoas(string frase);
    }
}