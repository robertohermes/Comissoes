using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.DolarMedioSpecs
{
    public class DolarMedioDtIniIsRequiredSpec : ISpecification<DolarMedio>
    {
        public bool IsSatisfiedBy(DolarMedio dolarmedio)
        {
            return dolarmedio.DT_INI.ToString().Trim().Length > 0;
        }
    }
}
