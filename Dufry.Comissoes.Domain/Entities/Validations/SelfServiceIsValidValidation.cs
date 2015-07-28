using Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class SelfServiceIsValidValidation : Validation<SelfService>
    {
        public SelfServiceIsValidValidation()
        {
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoCargoAlternateIsRequiredSpec(), ValidationMessages.SelfServiceCodigoCargoAlternateIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoCargoAlternateLenthMustBeLowerThan2Spec(), ValidationMessages.SelfServiceCodigoCargoAlternateLenthMustBeLowerThan2));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoLojaAlternateIsRequiredSpec(), ValidationMessages.SelfServiceCodigoLojaAlternateIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoLojaAlternateLenthMustBeLowerThan2Spec(), ValidationMessages.SelfServiceCodigoLojaAlternateLenthMustBeLowerThan2));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceDtFimIsRequiredSpec(), ValidationMessages.SelfServiceDtFimIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceDtIniIsRequiredSpec(), ValidationMessages.SelfServiceDtIniIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceStatusIsRequiredSpec(), ValidationMessages.SelfServiceStatusIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceStatusLenthMustBeLowerThan1Spec(), ValidationMessages.SelfServiceStatusLenthMustBeLowerThan1));

        }
    }
}
