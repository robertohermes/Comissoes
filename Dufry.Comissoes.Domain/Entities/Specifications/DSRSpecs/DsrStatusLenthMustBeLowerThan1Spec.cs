﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.DsrSpecs
{
    public class DsrStatusLenthMustBeLowerThan1Spec : ISpecification<DSR>
    {
        public bool IsSatisfiedBy(DSR dsr)
        {
            return dsr.STATUS.Trim().Length <= 1;
        }
    }
}
