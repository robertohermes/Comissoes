using Dufry.Comissoes.Domain.Entities.Specifications.DsrSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class DSRIsValidValidation : Validation<DSR>
    {
        public DSRIsValidValidation()
        {
            base.AddRule(new ValidationRule<DSR>(new DsrCodigoLojaAlternateIsRequiredSpec(), ValidationMessages.DsrCodigoLojaAlternateIsRequired));
            base.AddRule(new ValidationRule<DSR>(new DsrCodigoLojaAlternateLengthMustBeLowerThan2Spec(), ValidationMessages.DsrCodigoLojaAlternateLengthMustBeLowerThan2));
            base.AddRule(new ValidationRule<DSR>(new DsrDtFimIsRequiredSpec(), ValidationMessages.DsrDtFimIsRequired));
            base.AddRule(new ValidationRule<DSR>(new DsrDtIniIsRequiredSpec(), ValidationMessages.DsrDtIniIsRequired));
            base.AddRule(new ValidationRule<DSR>(new DsrPercentualShouldBeGraterThanZeroSpec(), ValidationMessages.DsrPercentualShouldBeGraterThanZero));
            base.AddRule(new ValidationRule<DSR>(new DsrPercentualShouldBeLowerThanOneSpec(), ValidationMessages.DsrPercentualShouldBeLowerThanOne));
            base.AddRule(new ValidationRule<DSR>(new DsrStatusIsRequiredSpec(), ValidationMessages.DsrStatusIsRequired));
            base.AddRule(new ValidationRule<DSR>(new DsrStatusLengthMustBeLowerThan1Spec(), ValidationMessages.DsrStatusLengthMustBeLowerThan1));

        }
    }
}
