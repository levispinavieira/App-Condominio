using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Condominios.Queries;
using App.Application.Condominios.ViewModels;
using App.Infra.Data.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Condominios.QueryHandlers
{
    public class ObterCondominiosQueryHandler: IRequestHandler<ObterCondominiosQuery, List<CondominioViewModel>>
    {
        private readonly IUnitOfWork _uow;

        public ObterCondominiosQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<CondominioViewModel>> Handle(ObterCondominiosQuery query, CancellationToken cancellationToken)
        {
            var condominiosViewModel = new List<CondominioViewModel>();
            
            var condominios = _uow.Condominios.ObterCondominios(query.Frase);

            if (condominios == null)
            {
                return null;
            }

            var condominiosList = await condominios.ToListAsync(cancellationToken);

            foreach (var condominio in condominiosList)
            {
                condominiosViewModel.Add(new CondominioViewModel()
                {
                    Id = condominio.Id,
                    Ativo = condominio.Ativo,
                    CadastradoEm = condominio.CadastradoEm,
                    DeletadoEm = condominio.DeletadoEm,
                    AtualizadoEm = condominio.AtualizadoEm,
                    Nome = condominio.Nome,
                    Telefone = condominio.Telefone,
                    EmailSindico = condominio.EmailSindico
                });
            }

            return condominiosViewModel;
        }
    }
}