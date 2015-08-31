using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
//using AutoMapper;


namespace Dufry.Comissoes.ViewModels
{
    public class SelfServiceViewModel
    {
        
        public SelfService SelfService { get; set; }

        public Cargo Cargo { get; set; }

        public Loja Loja { get; set; }

        public IEnumerable<SelectListItem> CargoSelectListItem { get; set; }

        public IEnumerable<SelectListItem> LojaSelectListItem { get; set; }

        public SelfServiceViewModel(SelfService selfService, Cargo cargo, Loja loja)
        {
            SelfService = selfService;
            Cargo = cargo;
            Loja = loja;
        }

        public SelfServiceViewModel(SelfService selfService, IEnumerable<SelectListItem> cargoSelectListItem, IEnumerable<SelectListItem> lojaSelectListItem)
        {
            SelfService = selfService;
            CargoSelectListItem = cargoSelectListItem;
            LojaSelectListItem = lojaSelectListItem;
        }

        //<REVER>
        //public SelfServiceViewModel ToViewModel(SelfService selfservice)
        //{
        //    return Mapper.Map<SelfServiceViewModel>(selfservice);
        //}
    }
}