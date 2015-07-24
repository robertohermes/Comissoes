namespace Dufry.Comissoes.Data.Context.Interfaces
{
    public interface IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        IDbContext GetComissoesContext();

        IDbContext GetBIVendasContext();

        void Finish();
    }
}