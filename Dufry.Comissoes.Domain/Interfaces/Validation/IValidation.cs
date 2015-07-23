using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}