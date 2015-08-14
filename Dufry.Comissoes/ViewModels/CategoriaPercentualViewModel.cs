using System;
using System.Collections.Generic;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.ViewModels
{
    public class CategoriaPercentualViewModel
    {
        public int ID_CATEGORIA_PERCENTUAL { get; set; }


        [Required(ErrorMessage = "A escolha de uma categoria é obrigatória")]
        [Display(Name = "Categoria")]
        public int ID_CATEGORIA { get; set; }


        [Required(ErrorMessage = "A descrição do atributo é obrigatória")]
        [StringLength(255, ErrorMessage = "A descrição do atributo não deve exceder 255 caracteres")]
        [Display(Name = "Atributo")]
        public string ATRIBUTO { get; set; }


        [Required(ErrorMessage = "A escolha de uma loja é obrigatória")]
        [Display(Name = "Código da Loja")]
        public decimal CODIGOLOJAALTERNATE { get; set; }
        
        
        [Required(ErrorMessage = "O percentual de comissão é obrigatório")]
        [Range(0.01, 100.00, ErrorMessage = "O valor do percentual de comissão deve estar entre 0.01 e 100.00")]
        [Display(Name = "Percentual de Comissão")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d+(\,\d)?$", ErrorMessage = "Apenas valores decimais são permitidos")]
        public decimal PERCENTUAL { get; set; }


        [Required(ErrorMessage = "A data inicial da vigência é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "A data inicial da vigência está em formato inválido")]
        [Display(Name = "Data inicial da vigência")]
        public DateTime DT_INI { get; set; }


        [Required(ErrorMessage = "A data final da vigência é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "A data final da vigência está em formato inválido")]
        [Display(Name = "Data final da vigência")]        
        public DateTime DT_FIM { get; set; }


        [Display(Name = "Status")]
        [Required(ErrorMessage = "O status do percentual é obrigatório")]
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<PlanoCategoria> PlanoCategorias { get; set; }

        public CategoriaPercentualViewModel ToViewModel(CategoriaPercentual categoriapercentual)
        {
            return Mapper.Map<CategoriaPercentualViewModel>(categoriapercentual);
        }
    }
}