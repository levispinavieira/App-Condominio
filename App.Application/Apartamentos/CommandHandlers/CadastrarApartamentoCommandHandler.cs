using System.Threading;
using System.Threading.Tasks;
using App.Application.Apartamentos.Commands;
using App.Application.Apartamentos.ViewModels;
using App.Domain.Apartamentos.Entities;
using App.Domain.Apartamentos.Interfaces;
using App.Domain.Blocos.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Apartamentos.CommandHandlers
{
    public class CadastrarApartamentoCommandHandler : IRequestHandler<CadastrarApartamentoCommand, CommandResult<ApartamentoViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBlocoService _blocoService;
        
        public CadastrarApartamentoCommandHandler(IUnitOfWork uow, IBlocoService blocoService)
        {
            _uow = uow;
            _blocoService = blocoService;
        }
        
        public async Task<CommandResult<ApartamentoViewModel>> Handle(CadastrarApartamentoCommand command, CancellationToken cancellationToken)
        {
            if (!await _blocoService.ExisteBloco(command.BlocoId)) return new CommandResult<ApartamentoViewModel>();

            var apartamento = new Apartamento(command.Id, command.Numero, command.Andar, command.BlocoId);

            if (!apartamento.EhValido())
            {
                return new CommandResult<ApartamentoViewModel>();
            }

            await _uow.Apartamentos.Adicionar(apartamento);  
            
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