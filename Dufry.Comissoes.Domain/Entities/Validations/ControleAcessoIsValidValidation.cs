using Dufry.Comissoes.Domain.Entities.Specifications.ControleAcessoSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class ControleAcessoIsValidValidation : Validation<ControleAcesso>
    {
        public ControleAcessoIsValidValidation()
        {
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoAdminIsRequiredSpec(), ValidationMessages.ControleAcessoAdminIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoAdminLenthMustBeLowerThan1Spec(), ValidationMessages.ControleAcessoAdminLenthMustBeLowerThan1));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoEmpresaAlternateIsRequiredSpec(), ValidationMessages.ControleAcessoCodigoEmpresaAlternateIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoEmpresaAlternateLenthMustBeLowerThan2Spec(), ValidationMessages.ControleAcessoCodigoEmpresaAlternateLenthMustBeLowerThan2));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoFilialAlternateIsRequiredSpec(), ValidationMessages.ControleAcessoCodigoFilialAlternateIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoFilialAlternateLenthMustBeLowerThan2Spec(), ValidationMessages.ControleAcessoCodigoFilialAlternateLenthMustBeLowerThan2));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoSecundarioIsRequiredSpec(), ValidationMessages.ControleAcessoCodigoSecundarioIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoSecundarioLenthMustBeLowerThan40Spec(), ValidationMessages.ControleAcessoCodigoSecundarioLenthMustBeLowerThan40));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoLoginIsRequiredSpec(), ValidationMessages.ControleAcessoLoginIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoLoginLenthMustBeLowerThan255Spec(), ValidationMessages.ControleAcessoLoginLenthMustBeLowerThan255));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoStatusIsRequiredSpec(), ValidationMessages.ControleAcessoStatusIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoStatusLenthMustBeLowerThan1Spec(), ValidationMessages.ControleAcessoStatusLenthMustBeLowerThan1));

            
        }
    }
}
