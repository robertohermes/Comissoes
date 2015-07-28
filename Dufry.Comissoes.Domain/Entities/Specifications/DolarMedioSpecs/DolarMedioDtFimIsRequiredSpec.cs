using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.DolarMedioSpecs
{
    public class DolarMedioDtFimIsRequiredSpec : ISpecification<DolarMedio>
    {
        public bool IsSatisfiedBy(DolarMedio dolarmedio)
        {
            return dolarmedio.DT_FIM.ToString().Trim().Length > 0;
        }
    }
}
