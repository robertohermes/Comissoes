﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaSpecs
{
    public class CategoriaTabOrigemIsRequiredSpec : ISpecification<Categoria>
    {
        public bool IsSatisfiedBy(Categoria categoria)
        {
            return categoria.TAB_ORIGEM.Trim().Length > 0;
        }
    }
}
