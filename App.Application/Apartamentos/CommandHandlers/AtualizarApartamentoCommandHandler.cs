using System.Threading;
using System.Threading.Tasks;
using App.Application.Apartamentos.Commands;
using App.Application.Apartamentos.ViewModels;
using App.Domain.Apartamentos.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Apartamentos.CommandHandlers
{
    public class AtualizarApartamentoCommandHandler: IRequestHandler<AtualizarApartamentoCommand, CommandResult<ApartamentoViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IApartamentoService _apartamentoService;
        
        public AtualizarApartamentoCommandHandler(IUnitOfWork uow, IApartamentoService apartamentoService)
        {
            _uow = uow;
            _apartamentoService = apartamentoService;
        }
        
        public async Task<CommandResult<ApartamentoViewModel>> Handle(AtualizarApartamentoCommand command, CancellationToken cancellationToken)
        {
            if (!await _apartamentoService.ExisteApartamento(command.Id)) return new CommandResult<ApartamentoViewModel>();

            var apartamento = await _uow.Apartamentos.ObterPorId(command.Id);

            apartamento.Andar = command.Andar;
            apartamento.Numero = command.Numero;

            if (!apartamento.EhValido())
            {
                return new CommandResult<ApartamentoViewModel>();
            }

            _uow.Apartamentos.Atualizar(apartamento);
             
            if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<ApartamentoViewModel>();
            }
            
            var apartamentoViewModel = new ApartamentoViewModel()
            {
                Id = apartamento.Id,
                Ativo = apartamento.Ativo,
                CadastradoEm = apartamento.CadastradoEm,
                DeletadoEm = apartamento.DeletadoEm,
                AtualizadoEm = apartamento.AtualizadoEm,
                Numero = apartamento.Numero,
                Andar = apartamento.Andar,
                BlocoId = apartamento.BlocoId
            };

            return new CommandResult<ApartamentoViewModel>(true, apartamentoViewModel);   
        }
    }
}