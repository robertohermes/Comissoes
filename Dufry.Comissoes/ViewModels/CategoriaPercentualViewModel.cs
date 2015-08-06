using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class CategoriaPercentualViewModel
    {
        public int ID_CATEGORIA_PERCENTUAL { get; set; }
        public int ID_CATEGORIA { get; set; }
        public string ATRIBUTO { get; set; }
        public string CODIGOLOJAALTERNATE { get; set; }
        public decimal PERCENTUAL { get; set; }
        public DateTime DT_INI { get; set; }
        public DateTime DT_FIM { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public CategoriaPercentualViewModel ToViewModel(CategoriaPercentual categoriapercentual)
        {
            return Mapper.Map<CategoriaPercentualViewModel>(categoriapercentual);
        }
    }
}