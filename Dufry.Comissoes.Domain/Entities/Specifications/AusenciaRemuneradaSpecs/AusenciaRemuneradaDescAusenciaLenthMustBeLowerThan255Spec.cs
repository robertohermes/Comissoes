using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.AusenciaRemuneradaSpecs
{
    public class AusenciaRemuneradaDescAusenciaLenthMustBeLowerThan255Spec : ISpecification<AusenciaRemunerada>
    {
        public bool IsSatisfiedBy(AusenciaRemunerada ausenciaremunerada)
        {
            return ausenciaremunerada.DESC_AUSENCIA.Trim().Length <= 255;
        }
    }
}
