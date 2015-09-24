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

        [Display(Name = "Nome do colaborador")]
        public string NomeCompleto { get; set; }

        [Display(Name = "Nome do superior")]
        public string NomeSuperiorCompleto { get; set; }

        public ControleAcesso ControleAcesso { get; set; }

        public IEnumerable<SelectListItem> SuperioresSelectListItem { get; set; }

        public IEnumerable<SelectListItem> ColaboradoresSelectListItem { get; set; }

        public CadastroAcessoViewModel(ControleAcesso controleAcesso, IEnumerable<SelectListItem> superioresSelectListItem, IEnumerable<SelectListItem> colaboradoresSelectListItem)
        {
            ControleAcesso = controleAcesso;
            SuperioresSelectListItem = superioresSelectListItem;
            ColaboradoresSelectListItem = colaboradoresSelectListItem;
            COLABORADORKEY_PAI = (controleAcesso.COLABORADORKEY_PAI == null) ? "0" : controleAcesso.COLABORADORKEY_PAI.ToString();
        }

        public CadastroAcessoViewModel(ControleAcesso controleAcesso, IEnumerable<SelectListItem> superioresSelectListItem, string nomeCompleto)
        {
            ControleAcesso = controleAcesso;
            SuperioresSelectListItem = superioresSelectListItem;
            COLABORADORKEY_PAI = (controleAcesso.COLABORADORKEY_PAI == null) ? "0" : controleAcesso.COLABORADORKEY_PAI.ToString();
            NomeCompleto = nomeCompleto;
        }

        public CadastroAcessoViewModel(ControleAcesso controleAcesso, string nomeSuperiorCompleto, string nomeCompleto)
        {
            ControleAcesso = controleAcesso;
            NomeSuperiorCompleto = nomeSuperiorCompleto;
            NomeCompleto = nomeCompleto;
        }

        //<REVER>
        //public ControleAcessoViewModel ToViewModel(ControleAcesso controleacesso)
        //{
        //    return Mapper.Map<ControleAcessoViewModel>(controleacesso);
        //}
    }
}