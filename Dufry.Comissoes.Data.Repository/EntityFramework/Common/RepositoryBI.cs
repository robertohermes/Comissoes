using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ServiceLocation;
using Dufry.Comissoes.Data.Context;
using Dufry.Comissoes.Data.Context.Interfaces;
using Dufry.Comissoes.Domain.Interfaces.Repository.Common;

namespace Dufry.Comissoes.Data.Repository.EntityFramework.Common
{
    public class RepositoryBI<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly IDbContext _dbContext2;
        private readonly IDbSet<TEntity> _dbSet;

        public RepositoryBI()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager<Vendas_DMContext>>()
                as ContextManager<Vendas_DMContext>;

            _dbContext2 = contextManager.GetContext2();
            _dbSet = _dbContext2.Set<TEntity>();
        }

        protected IDbContext Context
        {
            get { return _dbContext2; }
        }

        protected IDbSet<TEntity> DbSet
        {
            get { return _dbSet; }
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> All(bool @readonly = false)
        {
            return @readonly
                ? DbSet.AsNoTracking().ToList()
                : DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly
                ? DbSet.Where(predicate).AsNoTracking()
                : DbSet.Where(predicate);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }

        #endregion
    }
}
