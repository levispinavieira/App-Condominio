using System.Threading;
using System.Threading.Tasks;
using App.Application.Condominios.Commands;
using App.Domain.Condominios.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Condominios.CommandHandlers
{
    public class DeletarCondominioCommandHandler: IRequestHandler<DeletarCondominioCommand, CommandResult<bool>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICondominioService _condominioService;
        
        public DeletarCondominioCommandHandler(IUnitOfWork uow, ICondominioService condominioService)
        {
            _uow = uow;
            _condominioService = condominioService;
        }
        
        public async Task<CommandResult<bool>> Handle(DeletarCondominioCommand command, CancellationToken cancellationToken)
        {
            if (!await _condominioService.ExisteCondominio(command.Id)) return new CommandResult<bool>();

            var condominio = await _uow.Condominios.ObterPorId(command.Id);

            if (!condominio.EhValido())
            {
                return new CommandResult<bool>();
            }

            _uow.Condominios.Remover(condominio);
             
             if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<bool>();
            }

            return new CommandResult<bool>(true, true);   
        }
    }
}