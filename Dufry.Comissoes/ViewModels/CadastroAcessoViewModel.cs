using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class CadastroAcessoViewModel
    {
        [Required(ErrorMessage = "É necessário informar o superior")]
        [Display(Name = "Nome do superior")]
        public string COLABORADORKEY_PAI { get; set; }

        [Required(ErrorMessage = "A escolha de um colaborador é obrigatória")]
        [Display(Name = "Nome do colaborador")]
        public string COLABORADORKEY_ALT { get; set; }
        public ControleAcesso ControleAcesso { get; set; }

        public IEnumerable<SelectListItem> SuperioresSelectListItem { get; set; }

        public IEnumerable<SelectListItem> ColaboradoresSelectListItem { get; set; }

        public CadastroAcessoViewModel(ControleAcesso controleAcesso, IEnumerable<SelectListItem> superioresSelectListItem, IEnumerable<SelectListItem> colaboradoresSelectListItem)
        {
            ControleAcesso = controleAcesso;
            SuperioresSelectListItem = superioresSelectListItem;
            ColaboradoresSelectListItem = colaboradoresSelectListItem;
        }

        //<REVER>
        //public ControleAcessoViewModel ToViewModel(ControleAcesso controleacesso)
        //{
        //    return Mapper.Map<ControleAcessoViewModel>(controleacesso);
        //}
    }
}