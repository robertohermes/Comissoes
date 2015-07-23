using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Application.Interfaces.Common
{
    public interface IWriteOnlyAppService<in TEntity>
    where TEntity : class
    {
        ValidationResult Create(TEntity orderDetail);
        ValidationResult Update(TEntity orderDetail);
        ValidationResult Remove(TEntity orderDetail);
    }

}