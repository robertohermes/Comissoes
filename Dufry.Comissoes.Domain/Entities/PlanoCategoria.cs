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
        public int ID_PLANO_CATEGORIA { get; set; }

        [Required(ErrorMessage = "A escolha de um plano é obrigatória")]
        [Display(Name = "Plano")]
        public int ID_PLANO { get; set; }


        [Required(ErrorMessage = "A escolha de uma categoria é obrigatória")]
        [Display(Name = "Categoria")]
        public int ID_CATEGORIA { get; set; }


        [Required(ErrorMessage = "O valor hierárquico é obrigatório")]
        [Display(Name = "Valor hierárquico")]
        public int ORDEM_HIERARQUIA { get; set; }
        
        public DateTime CREATED_DATETIME { get; set; }
        
        public string CREATED_USERNAME { get; set; }
        
        public DateTime LAST_MODIFY_DATE { get; set; }
        
        public string LAST_MODIFY_USERNAME { get; set; }

        public virtual Plano Plano { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<CategoriaPercentual> CategoriaPercentuals { get; set; }

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
