using System.Threading;
using System.Threading.Tasks;
using App.Application.Condominios.Commands;
using App.Application.Condominios.ViewModels;
using App.Domain.Condominios.Entities;
using App.Domain.Condominios.Interfaces;
using App.Infra.Bus.Models;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Condominios.CommandHandlers
{
    public class CadastrarCondominioCommandHandler: IRequestHandler<CadastrarCondominioCommand, CommandResult<CondominioViewModel>>
    {
        private readonly IUnitOfWork _uow;

        public CadastrarCondominioCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task<CommandResult<CondominioViewModel>> Handle(CadastrarCondominioCommand command, CancellationToken cancellationToken)
        {
            var condominio = new Condominio(command.Id, command.Nome, command.Telefone, command.EmailSindico);

            if (!condominio.EhValido())
            {
                return new CommandResult<CondominioViewModel>();
            }

            await _uow.Condominios.Adicionar(condominio);  
            
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