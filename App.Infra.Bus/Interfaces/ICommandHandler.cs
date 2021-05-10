using App.Infra.Bus.Models;
using MediatR;

namespace App.Infra.Bus.Interfaces
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, bool> where TCommand: ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, CommandResult<TResponse>> where TCommand : ICommand<TResponse>
    {
    }
}
