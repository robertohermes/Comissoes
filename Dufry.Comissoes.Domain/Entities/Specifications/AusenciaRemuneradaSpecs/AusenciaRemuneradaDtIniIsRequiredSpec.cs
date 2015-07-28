using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.AusenciaRemuneradaSpecs
{
    public class AusenciaRemuneradaDtIniIsRequiredSpec : ISpecification<AusenciaRemunerada>
    {
        public bool IsSatisfiedBy(AusenciaRemunerada ausenciaremunerada)
        {
            return ausenciaremunerada.DT_INI.ToString().Trim().Length > 0;
        }
    }
}
