using Dufry.Comissoes.Data.Context.Interfaces;

namespace Dufry.Comissoes.Application.Interfaces.Common
{
    public interface ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void Commit();
    }
}
