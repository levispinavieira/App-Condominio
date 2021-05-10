using System.Threading;
using System.Threading.Tasks;
using App.Application.Pessoas.Queries;
using App.Application.Pessoas.ViewModels;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Pessoas.QueryHandlers
{
    public class ObterPessoaPorIdQueryHandler: IRequestHandler<ObterPessoaPorIdQuery, PessoaViewModel>
    {
        private readonly IUnitOfWork _uow;

        public ObterPessoaPorIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<PessoaViewModel> Handle(ObterPessoaPorIdQuery query, CancellationToken cancellationToken)
        {
            var pessoa = await _uow.Pessoas.ObterPorId(query.Id);    
            
            if (pessoa == null)
            {
                return null;
            }
            
            var pessoaViewModel = new PessoaViewModel()
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
            };

            return pessoaViewModel;
        }
    }
}