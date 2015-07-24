namespace Dufry.Comissoes.Data.Context.Interfaces
{
    public interface IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        IDbContext GetContext();

        IDbContext GetContext2();

        void Finish();
    }
}