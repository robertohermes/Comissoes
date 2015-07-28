﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.PlanoSpecs
{
    public class PlanoStatusLenthMustBeLowerThan1Spec : ISpecification<Plano>
    {
        public bool IsSatisfiedBy(Plano plano)
        {
            return plano.STATUS.Trim().Length <= 1;
        }
    }
}
