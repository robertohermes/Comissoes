
//using System;
using System.Collections.Generic;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities
{
    
    public partial class Categoria
    {
        public int ID_CATEGORIA { get; set; }
        public string DESC_CATEGORIA { get; set; }
        public string TAB_ORIGEM { get; set; }
        public string COL_ORIGEM { get; set; }
        public string STATUS { get; set; }
        public System.DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public System.DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new CategoriaIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
