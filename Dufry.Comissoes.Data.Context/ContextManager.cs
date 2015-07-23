using System.Web;
using Dufry.Comissoes.Data.Context.Interfaces;

namespace Dufry.Comissoes.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        private const string ContextKey = "ContextManager.Context";

        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
                HttpContext.Current.Items[ContextKey] = new TContext();
            return HttpContext.Current.Items[ContextKey] as IDbContext;
        }

        public void Finish()
        {
            if (HttpContext.Current.Items[ContextKey] != null)
                (HttpContext.Current.Items[ContextKey] as IDbContext).Dispose();
        }
    }
}