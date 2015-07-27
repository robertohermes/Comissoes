using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class ControleAcesso
    {
        public int COLABORADORKEY { get; set; }

        public int ? COLABORADORKEY_PAI { get; set; }

        public string CODIGOSECUNDARIO { get; set; }

        public string CODIGOEMPRESAALTERNATE { get; set; }

        public string CODIGOFILIALALTERNATE { get; set; }

        public string LOGIN { get; set; }
        
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
                var fiscal = new ControleAcessoIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
