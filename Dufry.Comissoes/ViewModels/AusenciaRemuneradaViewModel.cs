using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class AusenciaRemuneradaViewModel
    {
        public AusenciaRemunerada AusenciaRemunerada { get; set; }

        [Display(Name = "Nome do colaborador")]
        public string NomeCompleto { get; set; }

        public IEnumerable<SelectListItem> ColaboradoresSelectListItem { get; set; }

        public AusenciaRemuneradaViewModel(AusenciaRemunerada ausenciaRemunerada, IEnumerable<SelectListItem> colaboradoresSelectListItem)
        {
            AusenciaRemunerada = ausenciaRemunerada;
            ColaboradoresSelectListItem = colaboradoresSelectListItem;
        }

        public AusenciaRemuneradaViewModel(AusenciaRemunerada ausenciaRemunerada, string nomeCompleto)
        {
            AusenciaRemunerada = ausenciaRemunerada;
            NomeCompleto = nomeCompleto;
        }

        //<REVER>
        //public AusenciaRemuneradaViewModel ToViewModel(AusenciaRemunerada ausenciaremunerada)
        //{
        //    return Mapper.Map<AusenciaRemuneradaViewModel>(ausenciaremunerada);
        //}
    }
}