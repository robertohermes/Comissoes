using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class SelfService
    {
        public int ID_SELF_SERVICE { get; set; }


        [Required(ErrorMessage = "A escolha de um cargo é obrigatória")]
        [Display(Name = "Cargo")]
        public string CODIGOCARGOALTERNATE { get; set; }

        [Required(ErrorMessage = "A escolha de uma loja é obrigatória")]
        [Display(Name = "Loja")]
        public string CODIGOLOJAALTERNATE { get; set; }


        [Required(ErrorMessage = "A data inicial da vigência é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "A data inicial da vigência está em formato inválido")]
        [Display(Name = "Data inicial da vigência")]
        public DateTime DT_INI { get; set; }


        [Required(ErrorMessage = "A data final da vigência é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "A data final da vigência está em formato inválido")]
        [Display(Name = "Data final da vigência")]
        public DateTime DT_FIM { get; set; }


        [Display(Name = "Status")]
        [Required(ErrorMessage = "O status é obrigatório")]
        public string STATUS { get; set; }
        
        public DateTime CREATED_DATETIME { get; set; }
        
        public string CREATED_USERNAME { get; set; }
        
        public DateTime LAST_MODIFY_DATE { get; set; }
        
        public string LAST_MODIFY_USERNAME { get; set; }

        //public ValidationResult ValidationResult { get; private set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        var fiscal = new SelfServiceIsValidValidation();
        //        ValidationResult = fiscal.Valid(this);
        //        return ValidationResult.IsValid;
        //    }
        //}

    }
}
