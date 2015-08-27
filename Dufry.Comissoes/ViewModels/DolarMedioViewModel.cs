using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class DolarMedioViewModel
    {

        public DolarMedio DolarMedio { get; set; }

        public IEnumerable<SelectListItem> PlanosSelectListItem { get; set; }

        public DolarMedioViewModel(DolarMedio dolarMedio)
        {
            DolarMedio = dolarMedio;
        }

        public DolarMedioViewModel(DolarMedio dolarMedio, IEnumerable<SelectListItem> planosSelectListItem)
        {
            DolarMedio = dolarMedio;
            PlanosSelectListItem = planosSelectListItem;
        }

        //<REVER>
        //public DolarMedioViewModel ToViewModel(DolarMedio dolarmedio)
        //{
        //    return Mapper.Map<DolarMedioViewModel>(dolarmedio);
        //}
    }
}