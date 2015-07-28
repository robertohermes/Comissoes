﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaSpecs
{
    public class CategoriaColOrigemIsRequiredSpec : ISpecification<Categoria>
    {
        public bool IsSatisfiedBy(Categoria categoria)
        {
            return categoria.COL_ORIGEM.Trim().Length > 0;
        }
    }
}
