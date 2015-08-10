using System;
using System.Collections.Generic;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.ViewModels
{
    public class CategoriaViewModel
    {

        public int ID_CATEGORIA { get; set; }
        [Required(ErrorMessage = "A descrição da categoria é obrigatória")]
        [StringLength(255, ErrorMessage = "A descrição da categoria não deve exceder 255 caracteres")]
        [Display(Name = "Descrição")]
        public string DESC_CATEGORIA { get; set; }
        [Display(Name = "Tabela")]
        [Required(ErrorMessage = "A tabela de origem da categoria é obrigatória")]
        [StringLength(255, ErrorMessage = "A tabela de origem da categoria não deve exceder 255 caracteres")]
        public string TAB_ORIGEM { get; set; }
        [Display(Name = "Coluna")]
        [Required(ErrorMessage = "A coluna de origem da categoria é obrigatória")]
        [StringLength(255, ErrorMessage = "A coluna de origem da categoria não deve exceder 255 caracteres")]
        public string COL_ORIGEM { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "O status da categoria é obrigatório")]
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public virtual ICollection<CategoriaPercentual> CategoriaPercentuals { get; set; }

        public CategoriaViewModel ToViewModel(Categoria categoria)
        {
            return Mapper.Map<CategoriaViewModel>(categoria);
        }
    }
}