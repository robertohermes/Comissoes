using System;
using System.Collections.Generic;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class PlanoCategoria
    {
        [Required(ErrorMessage = "A escolha de um plano é obrigatório")]
        [Display(Name = "Plano")]
        public int ID_PLANO { get; set; }


        [Required(ErrorMessage = "A escolha de uma categoria e percentual por loja obrigatório")]
        [Display(Name = "Categoria e percentual por loja")]
        public int ID_CATEGORIA_PERCENTUAL { get; set; }


        [Required(ErrorMessage = "O valor hierárquico é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "A data inicial da vigência está em formato inválido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Valor hierárquico")]
        
        public int ORDEM_HIERARQUIA { get; set; }
        
        public DateTime CREATED_DATETIME { get; set; }
        
        public string CREATED_USERNAME { get; set; }
        
        public DateTime LAST_MODIFY_DATE { get; set; }
        
        public string LAST_MODIFY_USERNAME { get; set; }

        //public ValidationResult ValidationResult { get; private set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        var fiscal = new PlanoCategoriaIsValidValidation();
        //        ValidationResult = fiscal.Valid(this);
        //        return ValidationResult.IsValid;
        //    }
        //}

    }
}
