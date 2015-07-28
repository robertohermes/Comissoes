using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs
{
    public class SelfServiceDtFimIsRequiredSpec : ISpecification<SelfService>
    {
        public bool IsSatisfiedBy(SelfService selfservice)
        {
            return selfservice.DT_FIM.ToString().Trim().Length > 0;
        }
    }
}
