using Microsoft.Practices.ServiceLocation;
using Dufry.Comissoes.Application.Interfaces.Common;
using Dufry.Comissoes.Data.Context.Interfaces;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Application
{
    public class AppService<TContext> : ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        public AppService()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; private set; }

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }

}
