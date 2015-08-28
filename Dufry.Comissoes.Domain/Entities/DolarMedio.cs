using System;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class DolarMedio
    {
        public int ID_DOLAR_MEDIO { get; set; }

        [Required(ErrorMessage = "A escolha de um plano de comissões é obrigatória")]
        [Display(Name = "Plano de comissões")]
        public int ID_PLANO { get; set; }

        [Display(Name = "Tipo de taxa")]
        [Required(ErrorMessage = "O tipo de taxa é obrigatório")]
        public string TIPO_TAXA { get; set; }


        [Required(ErrorMessage = "O valor é obrigatório")]
        [Display(Name = "Dólar - Valor Médio (em R$)")]
        public decimal ? VALOR_DOLAR_MEDIO { get; set; }


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


        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public virtual Plano Plano { get; set; }

        //public ValidationResult ValidationResult { get; private set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        var fiscal = new DolarMedioIsValidValidation();
        //        ValidationResult = fiscal.Valid(this);
        //        return ValidationResult.IsValid;
        //    }
        //}

    }
}
