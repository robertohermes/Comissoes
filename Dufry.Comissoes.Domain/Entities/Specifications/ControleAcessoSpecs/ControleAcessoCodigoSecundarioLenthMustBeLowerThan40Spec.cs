﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.ControleAcessoSpecs
{
    public class ControleAcessoCodigoSecundarioLenthMustBeLowerThan40Spec : ISpecification<ControleAcesso>
    {
        public bool IsSatisfiedBy(ControleAcesso controleacesso)
        {
            return controleacesso.CODIGOSECUNDARIO.Trim().Length <= 40;
        }
    }
}
