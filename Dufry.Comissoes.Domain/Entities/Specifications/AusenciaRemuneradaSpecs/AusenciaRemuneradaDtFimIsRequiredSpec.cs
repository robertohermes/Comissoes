using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.AusenciaRemuneradaSpecs
{
    public class AusenciaRemuneradaDtFimIsRequiredSpec : ISpecification<AusenciaRemunerada>
    {
        public bool IsSatisfiedBy(AusenciaRemunerada ausenciaremunerada)
        {
            return ausenciaremunerada.DT_FIM.ToString().Trim().Length > 0;
        }
    }
}
