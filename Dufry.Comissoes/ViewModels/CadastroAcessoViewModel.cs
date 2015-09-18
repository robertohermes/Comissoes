using Dufry.Comissoes.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class CadastroAcessoViewModel
    {
        string IdSuperiorAlternate { get; set; }

        public ControleAcesso ControleAcesso { get; set; }

        public IEnumerable<SelectListItem> SuperioresSelectListItem { get; set; }

        public IEnumerable<SelectListItem> FuncionariosSelectListItem { get; set; }

        public CadastroAcessoViewModel(ControleAcesso controleAcesso, IEnumerable<SelectListItem> superioresSelectListItem, IEnumerable<SelectListItem> funcionariosSelectListItem)
        {
            ControleAcesso = controleAcesso;
            SuperioresSelectListItem = superioresSelectListItem;
            FuncionariosSelectListItem = funcionariosSelectListItem;
        }

        //<REVER>
        //public ControleAcessoViewModel ToViewModel(ControleAcesso controleacesso)
        //{
        //    return Mapper.Map<ControleAcessoViewModel>(controleacesso);
        //}
    }
}