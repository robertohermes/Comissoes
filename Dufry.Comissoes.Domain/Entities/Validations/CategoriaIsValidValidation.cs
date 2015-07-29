using Dufry.Comissoes.Domain.Entities.Specifications.CategoriaSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class CategoriaIsValidValidation : Validation<Categoria>
    {
        public CategoriaIsValidValidation()
        {
            base.AddRule(new ValidationRule<Categoria>(new CategoriaColOrigemIsRequiredSpec(), ValidationMessages.CategoriaColOrigemIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaColOrigemLengthMustBeLowerThan255Spec(), ValidationMessages.CategoriaColOrigemLengthMustBeLowerThan255));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaDescCategoriaIsRequiredSpec(), ValidationMessages.CategoriaDescCategoriaIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaDescCategoriaLengthMustBeLowerThan255Spec(), ValidationMessages.CategoriaDescCategoriaLengthMustBeLowerThan255));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaStatusIsRequiredSpec(), ValidationMessages.CategoriaStatusIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaStatusLengthMustBeLowerThan1Spec(), ValidationMessages.CategoriaStatusLengthMustBeLowerThan1));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaTabOrigemIsRequiredSpec(), ValidationMessages.CategoriaTabOrigemIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaTabOrigemLengthMustBeLowerThan255Spec(), ValidationMessages.CategoriaTabOrigemLengthMustBeLowerThan255));


        }
    }
}
