using System;
using Microsoft.Practices.ServiceLocation;
using Dufry.Comissoes.Data.Context.Interfaces;

namespace Dufry.Comissoes.Data.Context
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
        where TContext : IDbContext, new()
    {
        private readonly ContextManager<TContext> _contextManager =
            ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;

        private readonly IDbContext _dbComissoesContext;
        private readonly IDbContext _dbBIVendasContext;
        private bool _disposed;

        public UnitOfWork()
        {
            _dbComissoesContext = _contextManager.GetComissoesContext();
            _dbBIVendasContext = _contextManager.GetBIVendasContext();
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbComissoesContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbComissoesContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}