using Dufry.Comissoes.Domain.Entities.Specifications.CategoriaPercentualSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class CategoriaPercentualIsValidValidation : Validation<CategoriaPercentual>
    {
        public CategoriaPercentualIsValidValidation()
        {
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualAtributoIsRequiredSpec(), ValidationMessages.CategoriaPercentualAtributoIsRequired));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualAtributoLengthMustBeLowerThan255Spec(), ValidationMessages.CategoriaPercentualAtributoLengthMustBeLowerThan255));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualCodigoLojaAlternateIsRequiredSpec(), ValidationMessages.CategoriaPercentualCodigoLojaAlternateIsRequired));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualCodigoLojaAlternateLengthMustBeLowerThan1Spec(), ValidationMessages.CategoriaPercentualCodigoLojaAlternateLengthMustBeLowerThan1));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualDtFimIsRequiredSpec(), ValidationMessages.CategoriaPercentualDtFimIsRequired));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualDtIniIsRequiredSpec(), ValidationMessages.CategoriaPercentualDtIniIsRequired));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualPercentualShouldBeGraterThanZeroSpec(), ValidationMessages.CategoriaPercentualPercentualShouldBeGraterThanZero));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualPercentualShouldBeLowerThanOneSpec(), ValidationMessages.CategoriaPercentualPercentualShouldBeLowerThanOne));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualStatusIsRequiredSpec(), ValidationMessages.CategoriaPercentualStatusIsRequired));
            base.AddRule(new ValidationRule<CategoriaPercentual>(new CategoriaPercentualStatusLengthMustBeLowerThan1Spec(), ValidationMessages.CategoriaPercentualStatusLengthMustBeLowerThan1));

        }
    }
}
