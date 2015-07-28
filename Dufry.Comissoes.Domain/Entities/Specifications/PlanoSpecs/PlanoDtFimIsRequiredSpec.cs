using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.PlanoSpecs
{
    public class PlanoDtFimIsRequiredSpec : ISpecification<Plano>
    {
        public bool IsSatisfiedBy(Plano plano)
        {
            return plano.DT_FIM.ToString().Trim().Length > 0;
        }
    }
}
