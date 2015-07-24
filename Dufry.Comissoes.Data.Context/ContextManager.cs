using System.Web;
using Dufry.Comissoes.Data.Context.Interfaces;

namespace Dufry.Comissoes.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        private const string ContextKey = "ContextManager.Context";
        private const string ContextKey2 = "ContextManager.Context2";

        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
                HttpContext.Current.Items[ContextKey] = new TContext();
            return HttpContext.Current.Items[ContextKey] as IDbContext;
        }

        public IDbContext GetContext2()
        {
            if (HttpContext.Current.Items[ContextKey2] == null)
                HttpContext.Current.Items[ContextKey2] = new TContext();
            return HttpContext.Current.Items[ContextKey2] as IDbContext;
        }

        public void Finish()
        {
            if (HttpContext.Current.Items[ContextKey] != null)
                (HttpContext.Current.Items[ContextKey] as IDbContext).Dispose();
        }
    }
}