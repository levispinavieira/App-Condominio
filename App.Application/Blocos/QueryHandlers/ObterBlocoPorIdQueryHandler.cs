using System.Threading;
using System.Threading.Tasks;
using App.Application.Blocos.Queries;
using App.Application.Blocos.ViewModels;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Blocos.QueryHandlers
{
    public class ObterBlocoPorIdQueryHandler: IRequestHandler<ObterBlocoPorIdQuery, BlocoViewModel>
    {
        private readonly IUnitOfWork _uow;

        public ObterBlocoPorIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<BlocoViewModel> Handle(ObterBlocoPorIdQuery query, CancellationToken cancellationToken)
        {
            var bloco = await _uow.Blocos.ObterPorId(query.Id);    
            
            if (bloco == null)
            {
                return null;
            }
            
            var BlocoViewModel = new BlocoViewModel()
            {
                Id = bloco.Id,
                Ativo = bloco.Ativo,
                CadastradoEm = bloco.CadastradoEm,
                DeletadoEm = bloco.DeletadoEm,
                AtualizadoEm = bloco.AtualizadoEm,
                Nome = bloco.Nome,
                CondominioId = bloco.CondominioId
            };

            return BlocoViewModel;
        }
    }
}