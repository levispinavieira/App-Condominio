using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Pessoas.Queries;
using App.Application.Pessoas.ViewModels;
using App.Domain.Apartamentos.Interfaces;
using App.Infra.Data.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Pessoas.QueryHandlers
{
    public class ObterPessoasPorApartamentoIdQueryHandler: IRequestHandler<ObterPessoasPorApartamentoIdQuery, List<PessoaViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IApartamentoService _apartamentoService;

        public ObterPessoasPorApartamentoIdQueryHandler(IUnitOfWork uow, IApartamentoService apartamentoService)
        {
            _uow = uow;
            _apartamentoService = apartamentoService;
        }
        
        public async Task<List<PessoaViewModel>> Handle(ObterPessoasPorApartamentoIdQuery query, CancellationToken cancellationToken)
        {
            if (!await _apartamentoService.ExisteApartamento(query.Id)) return null;
            
            var pessoasViewModel = new List<PessoaViewModel>();
            
            var pessoas = _uow.Pessoas.ObterPessoasPorApartamentoId(query.Id, query.Frase);

            if (pessoas == null)
            {
                return null;
            }

            var pessoasList = await pessoas.ToListAsync(cancellationToken);

            foreach (var pessoa in pessoasList)
            {
                pessoasViewModel.Add(new PessoaViewModel()
                {
                    Id = pessoa.Id,
                    Ativo = pessoa.Ativo,
                    CadastradoEm = pessoa.CadastradoEm,
                    DeletadoEm = pessoa.DeletadoEm,
                    AtualizadoEm = pessoa.AtualizadoEm,
                    NomeCompleto = pessoa.NomeCompleto,
                    DataNascimento = pessoa.DataNascimento,
                    Telefone = pessoa.Telefone,
                    Cpf = pessoa.Cpf,
                    Email = pessoa.Email,
                    ApartamentoId = pessoa.ApartamentoId
                });
            }

            return pessoasViewModel;
        }
    }
}