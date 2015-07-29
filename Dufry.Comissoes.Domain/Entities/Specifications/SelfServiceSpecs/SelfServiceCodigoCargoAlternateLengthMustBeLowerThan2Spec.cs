using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs
{
    public class SelfServiceCodigoCargoAlternateLengthMustBeLowerThan2Spec : ISpecification<SelfService>
    {
        public bool IsSatisfiedBy(SelfService selfservice)
        {
            return selfservice.CODIGOCARGOALTERNATE.Trim().Length <= 2;
        }
    }
}
