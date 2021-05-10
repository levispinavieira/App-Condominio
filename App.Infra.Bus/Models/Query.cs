using App.Infra.Bus.Interfaces;

namespace App.Infra.Bus.Models
{
    public abstract class Query<TResponse> : IQuery<TResponse>
    {
    }
}
