using Dufry.Comissoes.Domain.Entities.Specifications.SelfServiceSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class SelfServiceIsValidValidation : Validation<SelfService>
    {
        public SelfServiceIsValidValidation()
        {
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoCargoAlternateIsRequiredSpec(), ValidationMessages.SelfServiceCodigoCargoAlternateIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoCargoAlternateLengthMustBeLowerThan2Spec(), ValidationMessages.SelfServiceCodigoCargoAlternateLengthMustBeLowerThan2));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoLojaAlternateIsRequiredSpec(), ValidationMessages.SelfServiceCodigoLojaAlternateIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceCodigoLojaAlternateLengthMustBeLowerThan2Spec(), ValidationMessages.SelfServiceCodigoLojaAlternateLengthMustBeLowerThan2));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceDtFimIsRequiredSpec(), ValidationMessages.SelfServiceDtFimIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceDtIniIsRequiredSpec(), ValidationMessages.SelfServiceDtIniIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceStatusIsRequiredSpec(), ValidationMessages.SelfServiceStatusIsRequired));
            base.AddRule(new ValidationRule<SelfService>(new SelfServiceStatusLengthMustBeLowerThan1Spec(), ValidationMessages.SelfServiceStatusLengthMustBeLowerThan1));

        }
    }
}
