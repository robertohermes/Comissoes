namespace Dufry.Comissoes.Domain.Interfaces.Validation
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}