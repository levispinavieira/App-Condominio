using System.Threading;
using System.Threading.Tasks;
using App.Application.Blocos.Commands;
using App.Domain.Blocos.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Blocos.CommandHandlers
{
    public class DeletarBlocoCommandHandler: IRequestHandler<DeletarBlocoCommand, CommandResult<bool>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBlocoService _blocoService;
        
        public DeletarBlocoCommandHandler(IUnitOfWork uow, IBlocoService blocoService)
        {
            _uow = uow;
            _blocoService = blocoService;
        }
        
        public async Task<CommandResult<bool>> Handle(DeletarBlocoCommand command, CancellationToken cancellationToken)
        {
            if (!await _blocoService.ExisteBloco(command.Id)) return new CommandResult<bool>();

            var bloco = await _uow.Blocos.ObterPorId(command.Id);

            if (!bloco.EhValido())
            {
                return new CommandResult<bool>();
            }

            _uow.Blocos.Remover(bloco);
             
            if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<bool>();
            }

            return new CommandResult<bool>(true, true);   
        }
    }
}