using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.AusenciaRemuneradaSpecs
{
    public class AusenciaRemuneradaStatusLenthMustBeLowerThan1Spec : ISpecification<AusenciaRemunerada>
    {
        public bool IsSatisfiedBy(AusenciaRemunerada ausenciaremunerada)
        {
            return ausenciaremunerada.STATUS.Trim().Length <= 1;
        }
    }
}
