using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Blocos.Queries;
using App.Application.Blocos.ViewModels;
using App.Infra.Data.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Blocos.QueryHandlers
{
    public class ObterBlocosQueryHandler: IRequestHandler<ObterBlocosQuery, List<BlocoViewModel>>
    {
        private readonly IUnitOfWork _uow;

        public ObterBlocosQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<BlocoViewModel>> Handle(ObterBlocosQuery query, CancellationToken cancellationToken)
        {
            var blocosViewModel = new List<BlocoViewModel>();
            
            var blocos = _uow.Blocos.ObterBlocos(query.Frase);

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