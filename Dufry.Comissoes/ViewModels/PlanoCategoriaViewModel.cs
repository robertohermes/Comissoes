using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//using AutoMapper;


namespace Dufry.Comissoes.ViewModels
{
    public class PlanoCategoriaViewModel
    {

        [Required(ErrorMessage = "A escolha de um plano é obrigatório")]
        [Display(Name = "Plano")]
        public int ID_PLANO { get; set; }

        public List<Categoria> CategoriasDisponiveisList { get; set; }

        public List<PlanoCategoria> PlanoCategoriasList { get; set; }

        public IEnumerable<SelectListItem> PlanosSelectListItem { get; set; }

        public PlanoCategoriaViewModel(List<PlanoCategoria> planoCategoriasList)
        {
            PlanoCategoriasList = planoCategoriasList;
        }

        public PlanoCategoriaViewModel(List<PlanoCategoria> planoCategoriasList, IEnumerable<SelectListItem> planosSelectListItem, List<Categoria> categoriasDisponiveisList)
        {
            PlanoCategoriasList = planoCategoriasList;
            PlanosSelectListItem = planosSelectListItem;
            CategoriasDisponiveisList = categoriasDisponiveisList;
        }

        //<REVER>
        //public PlanoCategoriaViewModel ToViewModel(PlanoCategoria planocategoria)
        //{
        //    return Mapper.Map<PlanoCategoriaViewModel>(planocategoria);
        //}
    }
}