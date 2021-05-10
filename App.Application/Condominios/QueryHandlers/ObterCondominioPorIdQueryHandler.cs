using System.Threading;
using System.Threading.Tasks;
using App.Application.Condominios.Queries;
using App.Application.Condominios.ViewModels;
using App.Infra.Data.Uow;
using MediatR;

namespace App.Application.Condominios.QueryHandlers
{
    public class ObterCondominioPorIdQueryHandler: IRequestHandler<ObterCondominioPorIdQuery, CondominioViewModel>
    {
        private readonly IUnitOfWork _uow;

        public ObterCondominioPorIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<CondominioViewModel> Handle(ObterCondominioPorIdQuery query, CancellationToken cancellationToken)
        {
            var condominio = await _uow.Condominios.ObterPorId(query.Id);    
            
            if (condominio == null)
            {
                return null;
            }
            
            var condominioViewModel = new CondominioViewModel()
            {
                Id = condominio.Id,
                Ativo = condominio.Ativo,
                CadastradoEm = condominio.CadastradoEm,
                DeletadoEm = condominio.DeletadoEm,
                AtualizadoEm = condominio.AtualizadoEm,
                Nome = condominio.Nome,
                Telefone = condominio.Telefone,
                EmailSindico = condominio.EmailSindico
            };

            return condominioViewModel;
        }
    }
}