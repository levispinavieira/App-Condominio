using System.Threading;
using System.Threading.Tasks;
using App.Application.Blocos.Commands;
using App.Application.Blocos.ViewModels;
using App.Domain.Blocos.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Blocos.CommandHandlers
{
    public class AtualizarBlocoCommandHandler: IRequestHandler<AtualizarBlocoCommand, CommandResult<BlocoViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBlocoService _blocoService;
        
        public AtualizarBlocoCommandHandler(IUnitOfWork uow, IBlocoService blocoService)
        {
            _uow = uow;
            _blocoService = blocoService;
        }
        
        public async Task<CommandResult<BlocoViewModel>> Handle(AtualizarBlocoCommand command, CancellationToken cancellationToken)
        {
            if (!await _blocoService.ExisteBloco(command.Id)) return new CommandResult<BlocoViewModel>();

            var bloco = await _uow.Blocos.ObterPorId(command.Id);

            bloco.Nome = command.Nome;

            if (!bloco.EhValido())
            {
                return new CommandResult<BlocoViewModel>();
            }

            _uow.Blocos.Atualizar(bloco);
             
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