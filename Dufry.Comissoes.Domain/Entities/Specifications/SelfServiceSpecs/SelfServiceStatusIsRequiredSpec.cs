using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs
{
    public class SelfServiceStatusIsRequiredSpec : ISpecification<SelfService>
    {
        public bool IsSatisfiedBy(SelfService selfservice)
        {
            return selfservice.STATUS.Trim().Length > 0;
        }
    }
}
