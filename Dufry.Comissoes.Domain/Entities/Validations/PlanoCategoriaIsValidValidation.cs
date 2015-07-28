using Dufry.Comissoes.Domain.Entities.Specifications.PlanoCategoriaSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class PlanoCategoriaIsValidValidation : Validation<PlanoCategoria>
    {
        public PlanoCategoriaIsValidValidation()
        {
            base.AddRule(new ValidationRule<PlanoCategoria>(new PlanoCategoriaOrdemHierarquiaIsRequiredSpec(), ValidationMessages.PlanoCategoriaOrdemHierarquiaIsRequired));

        }
    }
}
