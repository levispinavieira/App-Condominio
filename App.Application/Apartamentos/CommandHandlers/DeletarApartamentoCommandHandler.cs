using System.Threading;
using System.Threading.Tasks;
using App.Application.Apartamentos.Commands;
using App.Domain.Apartamentos.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Apartamentos.CommandHandlers
{
    public class DeletarApartamentoCommandHandler: IRequestHandler<DeletarApartamentoCommand, CommandResult<bool>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IApartamentoService _apartamentoService;
        
        public DeletarApartamentoCommandHandler(IUnitOfWork uow, IApartamentoService apartamentoService)
        {
            _uow = uow;
            _apartamentoService = apartamentoService;
        }
        
        public async Task<CommandResult<bool>> Handle(DeletarApartamentoCommand command, CancellationToken cancellationToken)
        {
            if (!await _apartamentoService.ExisteApartamento(command.Id)) return new CommandResult<bool>();

            var apartamento = await _uow.Apartamentos.ObterPorId(command.Id);

            if (!apartamento.EhValido())
            {
                return new CommandResult<bool>();
            }

            _uow.Apartamentos.Remover(apartamento);
             
            if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<bool>();
            }

            return new CommandResult<bool>(true, true);   
        }
    }
}