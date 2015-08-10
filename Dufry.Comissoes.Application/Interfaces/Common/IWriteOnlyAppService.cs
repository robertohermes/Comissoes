using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Application.Interfaces.Common
{
    public interface IWriteOnlyAppService<in TEntity>
    where TEntity : class
    {
        ValidationResult Create(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Remove(TEntity entity);
    }

}