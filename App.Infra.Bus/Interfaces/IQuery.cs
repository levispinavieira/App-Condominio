using MediatR;

namespace App.Infra.Bus.Interfaces
{
    public interface IQuery<TResponse>: IRequest<TResponse>
    {
    }
}
