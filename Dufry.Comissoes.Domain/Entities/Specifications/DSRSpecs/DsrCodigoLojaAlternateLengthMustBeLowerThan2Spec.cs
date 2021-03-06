﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.DsrSpecs
{
    public class DsrCodigoLojaAlternateLengthMustBeLowerThan2Spec : ISpecification<DSR>
    {
        public bool IsSatisfiedBy(DSR dsr)
        {
            return dsr.CODIGOLOJAALTERNATE.Trim().Length <= 255;
        }
    }
}
