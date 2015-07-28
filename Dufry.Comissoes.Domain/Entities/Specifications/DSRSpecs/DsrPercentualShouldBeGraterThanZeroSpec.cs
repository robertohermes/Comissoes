using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.DsrSpecs
{
    public class DsrPercentualShouldBeGraterThanZeroSpec : ISpecification<DSR>
    {
        public bool IsSatisfiedBy(DSR dsr)
        {
            return dsr.PERCENTUAL > 0;
        }
    }
}
