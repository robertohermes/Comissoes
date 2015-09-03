using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class AusenciaRemuneradaViewModel
    {
        public AusenciaRemunerada AusenciaRemunerada { get; set; }

        public IEnumerable<SelectListItem> ColaboradoresSelectListItem { get; set; }

        public AusenciaRemuneradaViewModel(AusenciaRemunerada ausenciaRemunerada, IEnumerable<SelectListItem> colaboradoresSelectListItem)
        {
            AusenciaRemunerada = ausenciaRemunerada;
            ColaboradoresSelectListItem = colaboradoresSelectListItem;
        }

        //<REVER>
        //public AusenciaRemuneradaViewModel ToViewModel(AusenciaRemunerada ausenciaremunerada)
        //{
        //    return Mapper.Map<AusenciaRemuneradaViewModel>(ausenciaremunerada);
        //}
    }
}