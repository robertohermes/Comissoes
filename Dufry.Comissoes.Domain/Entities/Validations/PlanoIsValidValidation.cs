﻿using Dufry.Comissoes.Domain.Entities.Specifications.PlanoSpecs;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities.Validations
{
    public class PlanoIsValidValidation : Validation<Plano>
    {
        public PlanoIsValidValidation()
        {
            base.AddRule(new ValidationRule<Plano>(new PlanoDescPlanoIsRequiredSpec(), ValidationMessages.PlanoDescPlanoIsRequired));
            base.AddRule(new ValidationRule<Plano>(new PlanoDescPlanoLenthMustBeLowerThan255Spec(), ValidationMessages.PlanoDescPlanoLenthMustBeLowerThan255));
            base.AddRule(new ValidationRule<Plano>(new PlanoDtFimIsRequiredSpec(), ValidationMessages.PlanoDtFimIsRequired));
            base.AddRule(new ValidationRule<Plano>(new PlanoDtIniIsRequiredSpec(), ValidationMessages.PlanoDtIniIsRequired));
            base.AddRule(new ValidationRule<Plano>(new PlanoStatusIsRequiredSpec(), ValidationMessages.PlanoStatusIsRequired));
            base.AddRule(new ValidationRule<Plano>(new PlanoStatusLenthMustBeLowerThan1Spec(), ValidationMessages.PlanoStatusLenthMustBeLowerThan1));

        }
    }
}
