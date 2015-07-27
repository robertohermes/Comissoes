using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class SelfServiceViewModel
    {
        public int ID_SELF_SERVICE { get; set; }
        public string CODIGOCARGOALTERNATE { get; set; }
        public string CODIGOLOJAALTERNATE { get; set; }
        public DateTime DT_INI { get; set; }
        public DateTime DT_FIM { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public static SelfServiceViewModel ToViewModel(SelfService selfservice)
        {
            return Mapper.Map<SelfServiceViewModel>(selfservice);
        }
    }
}