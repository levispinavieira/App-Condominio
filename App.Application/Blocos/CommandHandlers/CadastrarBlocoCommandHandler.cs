using System.Threading;
using System.Threading.Tasks;
using App.Application.Blocos.Commands;
using App.Application.Blocos.ViewModels;
using App.Domain.Blocos.Entities;
using App.Domain.Condominios.Entities;
using App.Domain.Condominios.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Blocos.CommandHandlers
{
    public class CadastrarBlocoCommandHandler: IRequestHandler<CadastrarBlocoCommand, CommandResult<BlocoViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICondominioService _condominioService;
        
        public CadastrarBlocoCommandHandler(IUnitOfWork uow, ICondominioService condominioService)
        {
            _uow = uow;
            _condominioService = condominioService;
        }
        
        public async Task<CommandResult<BlocoViewModel>> Handle(CadastrarBlocoCommand command, CancellationToken cancellationToken)
        {
            if (!await _condominioService.ExisteCondominio(command.CondominioId)) return new CommandResult<BlocoViewModel>();
            
            var bloco = new Bloco(command.Id, command.Nome, command.CondominioId);

            if (!bloco.EhValido())
            {
                return new CommandResult<BlocoViewModel>();
            }

            await _uow.Blocos.Adicionar(bloco);  
            
            if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<BlocoViewModel>();
            }

            var blocoViewModel = new BlocoViewModel()
            {
                Id = command.Id,
                Ativo = bloco.Ativo,
                CadastradoEm = bloco.CadastradoEm,
                DeletadoEm = bloco.DeletadoEm,
                AtualizadoEm = bloco.AtualizadoEm,
                Nome = bloco.Nome,
                CondominioId = bloco.CondominioId
            };
            
            return new CommandResult<BlocoViewModel>(true, blocoViewModel);   
        }
    }
}