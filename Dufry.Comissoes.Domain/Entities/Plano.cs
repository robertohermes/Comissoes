﻿using System;
using System.Collections.Generic;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Plano
    {

        public int ID_PLANO { get; set; }
        public string DESC_PLANO { get; set; }
        public DateTime DT_INI { get; set; }
        public DateTime DT_FIM { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }


        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new PlanoIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }

    }
}