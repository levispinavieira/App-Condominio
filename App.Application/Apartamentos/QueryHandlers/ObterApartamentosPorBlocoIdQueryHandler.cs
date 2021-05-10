using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using App.Application.Apartamentos.Queries;
using App.Application.Apartamentos.ViewModels;
using App.Domain.Blocos.Interfaces;
using App.Domain.Condominios.Interfaces;
using App.Infra.Data.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Apartamentos.QueryHandlers
{
    public class ObterApartamentosPorBlocoIdQueryHandler: IRequestHandler<ObterApartamentosPorBlocoIdQuery, List<ApartamentoViewModel>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IBlocoService _blocoService;

        public ObterApartamentosPorBlocoIdQueryHandler(IUnitOfWork uow, IBlocoService blocoService)
        {
            _uow = uow;
            _blocoService = blocoService;
        }
        
        public async Task<List<ApartamentoViewModel>> Handle(ObterApartamentosPorBlocoIdQuery query, CancellationToken cancellationToken)
        {
            if (!await _blocoService.ExisteBloco(query.Id)) return null;
            
            var apartamentosViewModel = new List<ApartamentoViewModel>();
            
            var apartamentos = _uow.Apartamentos.ObterApartamentosPorBlocoId(query.Id);

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