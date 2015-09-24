using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class ControleAcesso
    {
        public int COLABORADORKEY { get; set; }

        [Required(ErrorMessage = "É necessário informar o superior")]
        [Display(Name = "Nome do superior")]
        public int ? COLABORADORKEY_PAI { get; set; }

        public string CODIGOSECUNDARIO { get; set; }

        public string CODIGOEMPRESAALTERNATE { get; set; }

        public string CODIGOFILIALALTERNATE { get; set; }

        [Required(ErrorMessage = "O login é obrigatório")]
        [StringLength(255, ErrorMessage = "O login não deve exceder 255 caracteres")]
        [Display(Name = "Login")]
        public string LOGIN { get; set; }

        [Display(Name = "Administrador do sistema")]
        [Required(ErrorMessage = "Informe se é administrador ou não")]
        public string ADMIN { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "O status é obrigatório")]
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        //<REVER>
        //public virtual ICollection<ControleAcesso> ControleAcessoFilho { get; set; }

        public virtual ICollection<AusenciaRemunerada> AusenciaRemuneradas { get; set; }

        //public ValidationResult ValidationResult { get; private set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        var fiscal = new ControleAcessoIsValidValidation();
        //        ValidationResult = fiscal.Valid(this);
        //        return ValidationResult.IsValid;
        //    }
        //}
    }
}
