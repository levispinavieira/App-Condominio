using App.Infra.Bus.Interfaces;

namespace App.Infra.Bus.Models
{
    public abstract class Command: ICommand
    {
    }

    public abstract class Command<TResponse> : ICommand<TResponse>
    {
    }
}
