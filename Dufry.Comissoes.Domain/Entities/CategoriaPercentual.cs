﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class CategoriaPercentual
    {
        public int ID_CATEGORIA_PERCENTUAL { get; set; }


        [Required(ErrorMessage = "A escolha de uma categoria é obrigatória")]
        [Display(Name = "Categoria")]
        public int ID_PLANO_CATEGORIA { get; set; }


        [Required(ErrorMessage = "A descrição do atributo é obrigatória")]
        [StringLength(255, ErrorMessage = "A descrição do atributo não deve exceder 255 caracteres")]
        [Display(Name = "Atributo")]
        public string ATRIBUTO { get; set; }


        [Required(ErrorMessage = "O percentual de comissão é obrigatório")]
        [Range(0.01, 100.00, ErrorMessage = "O valor do percentual de comissão deve estar entre 0,01 e 100,00")]
        [Display(Name = "Percentual de Comissão")]
        public decimal PERCENTUAL { get; set; }


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

        //public virtual Categoria Categoria { get; set; }

        public virtual PlanoCategoria PlanoCategoria { get; set; }

        //public ValidationResult ValidationResult { get; private set; }

        //public bool IsValid
        //{
        //    get
        //    {
        //        var fiscal = new CategoriaPercentualIsValidValidation();
        //        ValidationResult = fiscal.Valid(this);
        //        return ValidationResult.IsValid;
        //    }
        //}

    }
}
