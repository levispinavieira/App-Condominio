using System.Threading;
using System.Threading.Tasks;
using App.Application.Pessoas.Commands;
using App.Domain.Pessoas.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Pessoas.CommandHandlers
{
    public class DeletarPessoaCommandHandler: IRequestHandler<DeletarPessoaCommand, CommandResult<bool>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IPessoaService _pessoaService;
        
        public DeletarPessoaCommandHandler(IUnitOfWork uow, IPessoaService pessoaService)
        {
            _uow = uow;
            _pessoaService = pessoaService;
        }
        
        public async Task<CommandResult<bool>> Handle(DeletarPessoaCommand command, CancellationToken cancellationToken)
        {
            if (!await _pessoaService.ExistePessoa(command.Id)) return new CommandResult<bool>();

            var pessoa = await _uow.Pessoas.ObterPorId(command.Id);

            if (!pessoa.EhValido())
            {
                return new CommandResult<bool>();
            }

            _uow.Pessoas.Remover(pessoa);
             
            if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<bool>();
            }

            return new CommandResult<bool>(true, true);   
        }
    }
}