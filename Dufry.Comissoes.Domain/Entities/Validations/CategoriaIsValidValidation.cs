using Dufry.Comissoes.Domain.Entities.Specifications.CategoriaSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class CategoriaIsValidValidation : Validation<Categoria>
    {
        public CategoriaIsValidValidation()
        {
            base.AddRule(new ValidationRule<Categoria>(new CategoriaColOrigemIsRequiredSpec(), ValidationMessages.CategoriaColOrigemIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaColOrigemLenthMustBeLowerThan255Spec(), ValidationMessages.CategoriaColOrigemLenthMustBeLowerThan255));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaDescCategoriaIsRequiredSpec(), ValidationMessages.CategoriaDescCategoriaIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaDescCategoriaLenthMustBeLowerThan255Spec(), ValidationMessages.CategoriaDescCategoriaLenthMustBeLowerThan255));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaStatusIsRequiredSpec(), ValidationMessages.CategoriaStatusIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaStatusLenthMustBeLowerThan1Spec(), ValidationMessages.CategoriaStatusLenthMustBeLowerThan1));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaTabOrigemIsRequiredSpec(), ValidationMessages.CategoriaTabOrigemIsRequired));
            base.AddRule(new ValidationRule<Categoria>(new CategoriaTabOrigemLenthMustBeLowerThan255Spec(), ValidationMessages.CategoriaTabOrigemLenthMustBeLowerThan255));


        }
    }
}
