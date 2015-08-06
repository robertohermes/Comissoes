using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class AusenciaRemuneradaViewModel
    {
        public int ID_AUSENCIA_REMUNERADA { get; set; }
        public int COLABORADORKEY { get; set; }
        public string DESC_AUSENCIA { get; set; }
        public DateTime DT_INI { get; set; }
        public DateTime DT_FIM { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public AusenciaRemuneradaViewModel ToViewModel(AusenciaRemunerada ausenciaremunerada)
        {
            return Mapper.Map<AusenciaRemuneradaViewModel>(ausenciaremunerada);
        }
    }
}