using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.PlanoCategoriaSpecs
{
    public class PlanoCategoriaOrdemHierarquiaIsRequiredSpec : ISpecification<PlanoCategoria>
    {
        public bool IsSatisfiedBy(PlanoCategoria planocategoria)
        {
            return planocategoria.ORDEM_HIERARQUIA > 0;
        }
    }
}
