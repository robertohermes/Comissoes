using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class PlanoViewModel
    {
        public int ID_PLANO { get; set; }
        public string DESC_PLANO { get; set; }
        public DateTime DT_INI { get; set; }
        public DateTime DT_FIM { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public static PlanoViewModel ToViewModel(Plano plano)
        {
            return Mapper.Map<PlanoViewModel>(plano);
        }
    }
}