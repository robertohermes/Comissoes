using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
//using AutoMapper;


namespace Dufry.Comissoes.ViewModels
{
    public class PlanoCategoriaViewModel
    {

        public PlanoCategoria PlanoCategoria { get; set; }

        public IEnumerable<SelectListItem> PlanosSelectListItem { get; set; }

        public PlanoCategoriaViewModel(PlanoCategoria planoCategoria)
        {
            PlanoCategoria = planoCategoria;
        }

        public PlanoCategoriaViewModel(PlanoCategoria planoCategoria, IEnumerable<SelectListItem> planosSelectListItem)
        {
            PlanoCategoria = planoCategoria;
            PlanosSelectListItem = planosSelectListItem;
        }

        //<REVER>
        //public PlanoCategoriaViewModel ToViewModel(PlanoCategoria planocategoria)
        //{
        //    return Mapper.Map<PlanoCategoriaViewModel>(planocategoria);
        //}
    }
}