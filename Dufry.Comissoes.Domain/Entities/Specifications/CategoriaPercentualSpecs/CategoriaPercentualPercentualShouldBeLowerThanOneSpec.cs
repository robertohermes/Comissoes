using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaPercentualSpecs
{
    public class CategoriaPercentualPercentualShouldBeLowerThanOneSpec : ISpecification<CategoriaPercentual>
    {
        public bool IsSatisfiedBy(CategoriaPercentual categoriapercentual)
        {
            return categoriapercentual.PERCENTUAL <= 1;
        }
    }
}
