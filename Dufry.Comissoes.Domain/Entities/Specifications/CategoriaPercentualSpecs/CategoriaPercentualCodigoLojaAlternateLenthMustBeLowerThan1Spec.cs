﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaPercentualSpecs
{
    public class CategoriaPercentualCodigoLojaAlternateLenthMustBeLowerThan1Spec : ISpecification<CategoriaPercentual>
    {
        public bool IsSatisfiedBy(CategoriaPercentual categoriapercentual)
        {
            return categoriapercentual.CODIGOLOJAALTERNATE.Trim().Length <= 1;
        }
    }
}