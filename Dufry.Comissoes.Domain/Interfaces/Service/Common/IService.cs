using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Interfaces.Service.Common
{
    public interface IService<TEntity>
        where TEntity : class
    {
        TEntity Get(int id, bool @readonly = false);
        IEnumerable<TEntity> All(bool @readonly = false);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);
        ValidationResult Add(TEntity department);
        ValidationResult Update(TEntity department);
        ValidationResult Delete(TEntity entity);
    }
}