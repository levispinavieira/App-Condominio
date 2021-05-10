using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Pessoas.Queries;
using App.Application.Pessoas.ViewModels;
using App.Infra.Data.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Pessoas.QueryHandlers
{
    public class ObterPessoasQueryHandler: IRequestHandler<ObterPessoasQuery, List<PessoaViewModel>>
    {
        private readonly IUnitOfWork _uow;

        public ObterPessoasQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<PessoaViewModel>> Handle(ObterPessoasQuery query, CancellationToken cancellationToken)
        {
            var pessoasViewModel = new List<PessoaViewModel>();
            
            var pessoas = _uow.Pessoas.ObterPessoas(query.Frase);

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