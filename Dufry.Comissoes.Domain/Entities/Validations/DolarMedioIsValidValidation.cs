using Dufry.Comissoes.Domain.Entities.Specifications.DolarMedioSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class DolarMedioIsValidValidation : Validation<DolarMedio>
    {
        public DolarMedioIsValidValidation()
        {
            base.AddRule(new ValidationRule<DolarMedio>(new DolarMedioDtFimIsRequiredSpec(), ValidationMessages.DolarMedioDtFimIsRequired));
            base.AddRule(new ValidationRule<DolarMedio>(new DolarMedioDtIniIsRequiredSpec(), ValidationMessages.DolarMedioDtIniIsRequired));
            base.AddRule(new ValidationRule<DolarMedio>(new DolarMedioValorDolarMedioShouldBeGraterThanZeroSpec(), ValidationMessages.DolarMedioValorDolarMedioShouldBeGraterThanZero));

        }
    }
}
