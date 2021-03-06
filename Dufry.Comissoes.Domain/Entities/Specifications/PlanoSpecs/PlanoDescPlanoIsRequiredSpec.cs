﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.PlanoSpecs
{
    public class PlanoDescPlanoIsRequiredSpec : ISpecification<Plano>
    {
        public bool IsSatisfiedBy(Plano plano)
        {
            return plano.DESC_PLANO.Trim().Length > 0;
        }
    }
}
