
using System;
using System.Collections.Generic;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    
    public partial class Categoria
    {
        public int ID_CATEGORIA { get; set; }
        
        [Required(ErrorMessage = "A descri��o da categoria � obrigat�ria")]
        [StringLength(255, ErrorMessage = "A descri��o da categoria n�o deve exceder 255 caracteres")]
        [Display(Name = "Descri��o")]
        public string DESC_CATEGORIA { get; set; }
        
        
        [Display(Name = "Tabela")]
        [Required(ErrorMessage = "A tabela de origem da categoria � obrigat�ria")]
        [StringLength(255, ErrorMessage = "A tabela de origem da categoria n�o deve exceder 255 caracteres")]
        public string TAB_ORIGEM { get; set; }
        
        
        [Display(Name = "Coluna")]
        [Required(ErrorMessage = "A coluna de origem da categoria � obrigat�ria")]
        [StringLength(255, ErrorMessage = "A coluna de origem da categoria n�o deve exceder 255 caracteres")]
        public string COL_ORIGEM { get; set; }
        
        
        [Display(Name = "Status")]
        [Required(ErrorMessage = "O status � obrigat�rio")]
        public string STATUS { get; set; }
        
        
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public virtual ICollection<PlanoCategoria> PlanoCategorias { get; set; }

        //public ValidationResult ValidationResult { get; private set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        var fiscal = new CategoriaIsValidValidation();
        //        ValidationResult = fiscal.Valid(this);
        //        return ValidationResult.IsValid;
        //    }
        //}
    }
}
