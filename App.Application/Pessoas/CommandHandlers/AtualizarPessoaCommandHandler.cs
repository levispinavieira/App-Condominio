using System.Threading;
using System.Threading.Tasks;
using App.Application.Pessoas.Commands;
using App.Application.Pessoas.ViewModels;
using App.Domain.Pessoas.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Pessoas.CommandHandlers
{
    public class AtualizarPessoaCommandHandler: IRequestHandler<AtualizarPessoaCommand, CommandResult<PessoaViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IPessoaService _pessoaService;
        
        public AtualizarPessoaCommandHandler(IUnitOfWork uow, IPessoaService pessoaService)
        {
            _uow = uow;
            _pessoaService = pessoaService;
        }
        
        public async Task<CommandResult<PessoaViewModel>> Handle(AtualizarPessoaCommand command, CancellationToken cancellationToken)
        {
            if (!await _pessoaService.ExistePessoa(command.Id)) return new CommandResult<PessoaViewModel>();

            var pessoa = await _uow.Pessoas.ObterPorId(command.Id);

            pessoa.NomeCompleto = command.NomeCompleto;
            pessoa.DataNascimento = command.DataNascimento;
            pessoa.Telefone = command.Telefone;
            pessoa.Cpf = command.Cpf;
            pessoa.Email = command.Email;

            if (!pessoa.EhValido())
            {
                return new CommandResult<PessoaViewModel>();
            }

            _uow.Pessoas.Atualizar(pessoa);
             
            if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<PessoaViewModel>();
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

            return new CommandResult<PessoaViewModel>(true, pessoaViewModel);   
        }
    }
}