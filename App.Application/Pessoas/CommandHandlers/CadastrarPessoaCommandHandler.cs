using System.Threading;
using System.Threading.Tasks;
using App.Application.Pessoas.Commands;
using App.Application.Pessoas.ViewModels;
using App.Domain.Apartamentos.Entities;
using App.Domain.Apartamentos.Interfaces;
using App.Domain.Blocos.Interfaces;
using App.Domain.Pessoas.Entities;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Pessoas.CommandHandlers
{
    public class CadastrarPessoaCommandHandler : IRequestHandler<CadastrarPessoaCommand, CommandResult<PessoaViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IApartamentoService _apartamentoService;
        
        public CadastrarPessoaCommandHandler(IUnitOfWork uow, IApartamentoService apartamentoService)
        {
            _uow = uow;
            _apartamentoService = apartamentoService;
        }
        
        public async Task<CommandResult<PessoaViewModel>> Handle(CadastrarPessoaCommand command, CancellationToken cancellationToken)
        {
            if (!await _apartamentoService.ExisteApartamento(command.ApartamentoId)) return new CommandResult<PessoaViewModel>();

            var pessoa = new Pessoa(command.Id, command.NomeCompleto, command.DataNascimento, command.Telefone, command.Cpf, command.Email, command.ApartamentoId);

            if (!pessoa.EhValido())
            {
                return new CommandResult<PessoaViewModel>();
            }

            await _uow.Pessoas.Adicionar(pessoa);  
            
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