using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs
{
    public class SelfServiceCodigoCargoAlternateIsRequiredSpec : ISpecification<SelfService>
    {
        public bool IsSatisfiedBy(SelfService selfservice)
        {
            return selfservice.CODIGOCARGOALTERNATE.Trim().Length > 0;
        }
    }
}
