using Dufry.Comissoes.Domain.Entities.Specifications.ControleAcessoSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class ControleAcessoIsValidValidation : Validation<ControleAcesso>
    {
        public ControleAcessoIsValidValidation()
        {
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoLoginLenthMustBeLowerThan255Spec(), ValidationMessages.ControleAcessoLoginLenthMustBeLowerThan100));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoLoginIsRequiredSpec(), ValidationMessages.ControleAcessoLoginLenthMustBeLowerThan100));
            
        }
    }
}
