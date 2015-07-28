using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaPercentualSpecs
{
    public class CategoriaPercentualStatusIsRequiredSpec : ISpecification<CategoriaPercentual>
    {
        public bool IsSatisfiedBy(CategoriaPercentual categoriapercentual)
        {
            return categoriapercentual.STATUS.Trim().Length > 0;
        }
    }
}
