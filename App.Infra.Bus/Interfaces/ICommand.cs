using App.Infra.Bus.Models;
using MediatR;

namespace App.Infra.Bus.Interfaces
{
    public interface ICommand: IRequest<bool>
    {
    }

    public interface ICommand<TResponse> : IRequest<CommandResult<TResponse>>
    {
    }
}
