using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.ViewModels
{
    public class CategoriaViewModel
    {

        public int ID_CATEGORIA { get; set; }
        [Display(Name = "Descrição")]
        public string DESC_CATEGORIA { get; set; }
        public string TAB_ORIGEM { get; set; }
        public string COL_ORIGEM { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public CategoriaViewModel ToViewModel(Categoria categoria)
        {
            return Mapper.Map<CategoriaViewModel>(categoria);
        }
    }
}