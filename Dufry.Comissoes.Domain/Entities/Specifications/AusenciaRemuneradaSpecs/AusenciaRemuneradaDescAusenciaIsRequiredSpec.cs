﻿using Dufry.Comissoes.Domain.Interfaces.Validation;

namespace Dufry.Comissoes.Domain.Entities.Specifications.AusenciaRemuneradaSpecs
{
    public class AusenciaRemuneradaDescAusenciaIsRequiredSpec : ISpecification<AusenciaRemunerada>
    {
        public bool IsSatisfiedBy(AusenciaRemunerada ausenciaremunerada)
        {
            return ausenciaremunerada.DESC_AUSENCIA.Trim().Length > 0;
        }
    }
}
