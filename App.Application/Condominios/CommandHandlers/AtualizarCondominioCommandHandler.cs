using System.Threading;
using System.Threading.Tasks;
using App.Application.Condominios.Commands;
using App.Application.Condominios.ViewModels;
using App.Domain.Condominios.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Condominios.CommandHandlers
{
    public class AtualizarCondominioCommandHandler: IRequestHandler<AtualizarCondominioCommand, CommandResult<CondominioViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICondominioService _condominioService;
        
        public AtualizarCondominioCommandHandler(IUnitOfWork uow, ICondominioService condominioService)
        {
            _uow = uow;
            _condominioService = condominioService;
        }
        
        public async Task<CommandResult<CondominioViewModel>> Handle(AtualizarCondominioCommand command, CancellationToken cancellationToken)
        {
            if (!await _condominioService.ExisteCondominio(command.Id)) return new CommandResult<CondominioViewModel>();

            var condominio = await _uow.Condominios.ObterPorId(command.Id);

            condominio.Nome = command.Nome;
            condominio.Telefone = command.Telefone;
            condominio.EmailSindico = command.EmailSindico;
            
            if (!condominio.EhValido())
            {
                return new CommandResult<CondominioViewModel>();
            }

            _uow.Condominios.Atualizar(condominio);
             
            if (!await _uow.Commit(cancellationToken))
            {
                return new CommandResult<CondominioViewModel>();
            }
            
            var condominioViewModel = new CondominioViewModel()
            {
                Id = command.Id,
                Ativo = condominio.Ativo,
                CadastradoEm = condominio.CadastradoEm,
                DeletadoEm = condominio.DeletadoEm,
                AtualizadoEm = condominio.AtualizadoEm,
                Nome = condominio.Nome,
                Telefone = condominio.Telefone,
                EmailSindico = condominio.EmailSindico
            };

            return new CommandResult<CondominioViewModel>(true, condominioViewModel);   
        }
    }
}