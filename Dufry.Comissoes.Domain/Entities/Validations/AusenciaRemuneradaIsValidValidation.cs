using Dufry.Comissoes.Domain.Entities.Specifications.AusenciaRemuneradaSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class AusenciaRemuneradaIsValidValidation : Validation<AusenciaRemunerada>
    {
        public AusenciaRemuneradaIsValidValidation()
        {
            base.AddRule(new ValidationRule<AusenciaRemunerada>(new AusenciaRemuneradaDescAusenciaIsRequiredSpec(), ValidationMessages.AusenciaRemuneradaDescAusenciaIsRequired));
            base.AddRule(new ValidationRule<AusenciaRemunerada>(new AusenciaRemuneradaDescAusenciaLengthMustBeLowerThan255Spec(), ValidationMessages.AusenciaRemuneradaDescAusenciaLengthMustBeLowerThan255));
            base.AddRule(new ValidationRule<AusenciaRemunerada>(new AusenciaRemuneradaDtFimIsRequiredSpec(), ValidationMessages.AusenciaRemuneradaDtFimIsRequired));
            base.AddRule(new ValidationRule<AusenciaRemunerada>(new AusenciaRemuneradaDtIniIsRequiredSpec(), ValidationMessages.AusenciaRemuneradaDtIniIsRequired));
            base.AddRule(new ValidationRule<AusenciaRemunerada>(new AusenciaRemuneradaStatusIsRequiredSpec(), ValidationMessages.AusenciaRemuneradaStatusIsRequired));
            base.AddRule(new ValidationRule<AusenciaRemunerada>(new AusenciaRemuneradaStatusLengthMustBeLowerThan1Spec(), ValidationMessages.AusenciaRemuneradaStatusLengthMustBeLowerThan1));

        }
    }
}
