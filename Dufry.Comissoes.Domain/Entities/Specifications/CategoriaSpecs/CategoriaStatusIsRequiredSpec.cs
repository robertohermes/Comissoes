﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.CategoriaSpecs
{
    public class CategoriaStatusIsRequiredSpec : ISpecification<Categoria>
    {
        public bool IsSatisfiedBy(Categoria categoria)
        {
            return categoria.STATUS.Trim().Length > 0;
        }
    }
}
