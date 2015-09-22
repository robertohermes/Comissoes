using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.ControleAcessoSpecs
{
    public class ControleAcessoCodigoEmpresaAlternateLengthMustBeLowerThan20Spec : ISpecification<ControleAcesso>
    {
        public bool IsSatisfiedBy(ControleAcesso controleacesso)
        {
            return controleacesso.CODIGOEMPRESAALTERNATE.Trim().Length <= 20;
        }
    }
}
