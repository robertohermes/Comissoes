using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class PlanoLojaViewModel
    {

        public PlanoLoja PlanoLoja { get; set; }

        public Loja Loja { get; set; }

        public IEnumerable<SelectListItem> PlanosSelectListItem { get; set; }

        public IEnumerable<SelectListItem> LojasSelectListItem { get; set; }

        public PlanoLojaViewModel(PlanoLoja planoLoja, Loja loja)
        {
            PlanoLoja = planoLoja;
            Loja = loja;
        }

        public PlanoLojaViewModel(PlanoLoja planoLoja, IEnumerable<SelectListItem> planosSelectListItem, IEnumerable<SelectListItem> lojaSelectListItem)
        {
            PlanoLoja = planoLoja;
            PlanosSelectListItem = planosSelectListItem;
            LojasSelectListItem = lojaSelectListItem;
        }

        //<REVER>
        //public PlanoLojaViewModel ToViewModel(PlanoLoja planoLoja)
        //{
        //    return Mapper.Map<PlanoLojaViewModel>(planoLoja);
        //}
    }
}