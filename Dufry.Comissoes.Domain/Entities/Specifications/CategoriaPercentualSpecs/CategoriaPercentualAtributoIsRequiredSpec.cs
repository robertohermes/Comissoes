﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaPercentualSpecs
{
    public class CategoriaPercentualAtributoIsRequiredSpec : ISpecification<CategoriaPercentual>
    {
        public bool IsSatisfiedBy(CategoriaPercentual categoriapercentual)
        {
            return categoriapercentual.ATRIBUTO.Trim().Length > 0;
        }
    }
}
