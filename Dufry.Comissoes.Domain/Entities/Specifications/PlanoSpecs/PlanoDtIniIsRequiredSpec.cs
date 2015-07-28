using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.PlanoSpecs
{
    public class PlanoDtIniIsRequiredSpec : ISpecification<Plano>
    {
        public bool IsSatisfiedBy(Plano plano)
        {
            return plano.DT_INI.ToString().Trim().Length > 0;
        }
    }
}
