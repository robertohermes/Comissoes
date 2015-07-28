using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs
{
    public class SelfServiceStatusLenthMustBeLowerThan1Spec : ISpecification<SelfService>
    {
        public bool IsSatisfiedBy(SelfService selfservice)
        {
            return selfservice.STATUS.Trim().Length <= 1;
        }
    }
}
