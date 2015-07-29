using Dufry.Comissoes.Domain.Entities.Specifications.ControleAcessoSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class ControleAcessoIsValidValidation : Validation<ControleAcesso>
    {
        public ControleAcessoIsValidValidation()
        {
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoAdminIsRequiredSpec(), ValidationMessages.ControleAcessoAdminIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoAdminLengthMustBeLowerThan1Spec(), ValidationMessages.ControleAcessoAdminLengthMustBeLowerThan1));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoEmpresaAlternateIsRequiredSpec(), ValidationMessages.ControleAcessoCodigoEmpresaAlternateIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoEmpresaAlternateLengthMustBeLowerThan2Spec(), ValidationMessages.ControleAcessoCodigoEmpresaAlternateLengthMustBeLowerThan2));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoFilialAlternateIsRequiredSpec(), ValidationMessages.ControleAcessoCodigoFilialAlternateIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoFilialAlternateLengthMustBeLowerThan2Spec(), ValidationMessages.ControleAcessoCodigoFilialAlternateLengthMustBeLowerThan2));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoSecundarioIsRequiredSpec(), ValidationMessages.ControleAcessoCodigoSecundarioIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoCodigoSecundarioLengthMustBeLowerThan40Spec(), ValidationMessages.ControleAcessoCodigoSecundarioLengthMustBeLowerThan40));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoLoginIsRequiredSpec(), ValidationMessages.ControleAcessoLoginIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoLoginLengthMustBeLowerThan255Spec(), ValidationMessages.ControleAcessoLoginLengthMustBeLowerThan255));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoStatusIsRequiredSpec(), ValidationMessages.ControleAcessoStatusIsRequired));
            base.AddRule(new ValidationRule<ControleAcesso>(new ControleAcessoStatusLengthMustBeLowerThan1Spec(), ValidationMessages.ControleAcessoStatusLengthMustBeLowerThan1));

            
        }
    }
}
