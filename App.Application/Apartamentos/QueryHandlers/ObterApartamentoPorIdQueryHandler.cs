using System.Threading;
using System.Threading.Tasks;
using App.Application.Apartamentos.Queries;
using App.Application.Apartamentos.ViewModels;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Apartamentos.QueryHandlers
{
    public class ObterApartamentoPorIdQueryHandler: IRequestHandler<ObterApartamentoPorIdQuery, ApartamentoViewModel>
    {
        private readonly IUnitOfWork _uow;

        public ObterApartamentoPorIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<ApartamentoViewModel> Handle(ObterApartamentoPorIdQuery query, CancellationToken cancellationToken)
        {
            var apartamento = await _uow.Apartamentos.ObterPorId(query.Id);    
            
            if (apartamento == null)
            {
                return null;
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

            return apartamentoViewModel;
        }
    }
}