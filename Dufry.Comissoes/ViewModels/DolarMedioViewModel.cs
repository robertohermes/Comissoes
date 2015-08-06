using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class DolarMedioViewModel
    {
        public int ID_PLANO { get; set; }
        public decimal VALOR_DOLAR_MEDIO { get; set; }
        public DateTime DT_INI { get; set; }
        public DateTime DT_FIM { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public DolarMedioViewModel ToViewModel(DolarMedio dolarmedio)
        {
            return Mapper.Map<DolarMedioViewModel>(dolarmedio);
        }
    }
}