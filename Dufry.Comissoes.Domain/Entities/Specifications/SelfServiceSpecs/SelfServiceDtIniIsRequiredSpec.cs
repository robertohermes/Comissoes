using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs
{
    public class SelfServiceDtIniIsRequiredSpec : ISpecification<SelfService>
    {
        public bool IsSatisfiedBy(SelfService selfservice)
        {
            return selfservice.DT_INI.ToString().Trim().Length > 0;
        }
    }
}
