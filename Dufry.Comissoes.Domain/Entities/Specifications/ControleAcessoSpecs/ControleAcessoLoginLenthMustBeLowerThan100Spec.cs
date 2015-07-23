using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.ControleAcessoSpecs
{
    public class ControleAcessoLoginLenthMustBeLowerThan255Spec : ISpecification<ControleAcesso>
    {
        public bool IsSatisfiedBy(ControleAcesso controleacesso)
        {
            return controleacesso.LOGIN.Trim().Length < 255;
        }
    }
}
