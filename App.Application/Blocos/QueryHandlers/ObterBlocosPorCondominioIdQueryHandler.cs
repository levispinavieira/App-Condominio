using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Blocos.Queries;
using App.Application.Blocos.ViewModels;
using App.Domain.Condominios.Interfaces;
using App.Infra.Data.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Blocos.QueryHandlers
{
    public class ObterBlocosPorCondominioIdQueryHandler: IRequestHandler<ObterBlocosPorCondominioIdQuery, List<BlocoViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICondominioService _condominioService;

        public ObterBlocosPorCondominioIdQueryHandler(IUnitOfWork uow, ICondominioService condominioService)
        {
            _uow = uow;
            _condominioService = condominioService;
        }
        
        public async Task<List<BlocoViewModel>> Handle(ObterBlocosPorCondominioIdQuery query, CancellationToken cancellationToken)
        {
            if (!await _condominioService.ExisteCondominio(query.Id)) return null;
            
            var blocosViewModel = new List<BlocoViewModel>();
            
            var blocos = _uow.Blocos.ObterBlocosPorCondominioId(query.Id, query.Frase);

            if (blocos == null)
            {
                return null;
            }

            var blocosList = await blocos.ToListAsync(cancellationToken);

            foreach (var bloco in blocosList)
            {
                blocosViewModel.Add(new BlocoViewModel()
                {
                    Id = bloco.Id,
                    Ativo = bloco.Ativo,
                    CadastradoEm = bloco.CadastradoEm,
                    DeletadoEm = bloco.DeletadoEm,
                    AtualizadoEm = bloco.AtualizadoEm,
                    Nome = bloco.Nome,
                    CondominioId = bloco.CondominioId
                });
            }

            return blocosViewModel;
        }
    }
}