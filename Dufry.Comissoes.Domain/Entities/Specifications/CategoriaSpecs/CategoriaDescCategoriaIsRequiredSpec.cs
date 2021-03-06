﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaSpecs
{
    public class CategoriaDescCategoriaIsRequiredSpec : ISpecification<Categoria>
    {
        public bool IsSatisfiedBy(Categoria categoria)
        {
            return categoria.DESC_CATEGORIA.Trim().Length > 0;
        }
    }
}
