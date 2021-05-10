using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Apartamentos.Queries;
using App.Application.Apartamentos.ViewModels;
using App.Infra.Data.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Apartamentos.QueryHandlers
{
    public class ObterApartamentosQueryHandler: IRequestHandler<ObterApartamentosQuery, List<ApartamentoViewModel>>
    {
        private readonly IUnitOfWork _uow;

        public ObterApartamentosQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<ApartamentoViewModel>> Handle(ObterApartamentosQuery query, CancellationToken cancellationToken)
        {
            var apartamentosViewModel = new List<ApartamentoViewModel>();
            
            var apartamentos = _uow.Apartamentos.ObterApartamentos();

            if (apartamentos == null)
            {
                return null;
            }

            var apartamentosList = await apartamentos.ToListAsync(cancellationToken);

            foreach (var apartamento in apartamentosList)
            {
                apartamentosViewModel.Add(new ApartamentoViewModel()
                {
                    Id = apartamento.Id,
                    Ativo = apartamento.Ativo,
                    CadastradoEm = apartamento.CadastradoEm,
                    DeletadoEm = apartamento.DeletadoEm,
                    AtualizadoEm = apartamento.AtualizadoEm,
                    Numero = apartamento.Numero,
                    Andar = apartamento.Andar,
                    BlocoId = apartamento.BlocoId
                });
            }

            return apartamentosViewModel;
        }
    }
}