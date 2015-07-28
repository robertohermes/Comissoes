using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.DolarMedioSpecs
{
    public class DolarMedioValorDolarMedioShouldBeGraterThanZeroSpec : ISpecification<DolarMedio>
    {
        public bool IsSatisfiedBy(DolarMedio dolarmedio)
        {
            return dolarmedio.VALOR_DOLAR_MEDIO > 0;
        }
    }
}
