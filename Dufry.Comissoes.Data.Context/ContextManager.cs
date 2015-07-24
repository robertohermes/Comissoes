using System.Web;
using Dufry.Comissoes.Data.Context.Interfaces;

namespace Dufry.Comissoes.Data.Context
{
    public class ContextManager<TContext> : IContextManager<TContext>
        where TContext : IDbContext, new()
    {
        private const string ComissoesContextKey = "ContextManager.ComissoesContext";
        private const string BIVendasContextKey = "ContextManager.BIVendasContext";

        public IDbContext GetComissoesContext()
        {
            if (HttpContext.Current.Items[ComissoesContextKey] == null)
                HttpContext.Current.Items[ComissoesContextKey] = new TContext();
            return HttpContext.Current.Items[ComissoesContextKey] as IDbContext;
        }

        public IDbContext GetBIVendasContext()
        {
            if (HttpContext.Current.Items[BIVendasContextKey] == null)
                HttpContext.Current.Items[BIVendasContextKey] = new TContext();
            return HttpContext.Current.Items[BIVendasContextKey] as IDbContext;
        }

        public void Finish()
        {
            if (HttpContext.Current.Items[ComissoesContextKey] != null)
                (HttpContext.Current.Items[ComissoesContextKey] as IDbContext).Dispose();

            if (HttpContext.Current.Items[BIVendasContextKey] != null)
                (HttpContext.Current.Items[BIVendasContextKey] as IDbContext).Dispose();
        }
    }
}