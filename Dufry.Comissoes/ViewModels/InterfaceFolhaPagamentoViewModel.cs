using Dufry.Comissoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class InterfaceFolhaPagamentoViewModel
    {
        [Display(Name = "Codigo da Folha")]
        public string CodigoFolha { get; set; }

        [Display(Name = "Codigo do Cliente")]
        public string CodigoClienteADP { get; set; }

        [Required(ErrorMessage = "O Processo Folha é obrigatório")]
        [Range(0, Int32.MaxValue, ErrorMessage = "O Processo Folha está em formato inválido")]
        [Display(Name = "Processo Folha")]
        public string NumeroProcessoFolha { get; set; }

        [Required(ErrorMessage = "A data inicial da vigência é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "A data inicial da vigência está em formato inválido")]
        [Display(Name = "Data inicial da vigência")]
        public DateTime DT_INI { get; set; }


        [Required(ErrorMessage = "A data final da vigência é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "A data final da vigência está em formato inválido")]
        [Display(Name = "Data final da vigência")]
        public DateTime DT_FIM { get; set; }

        //public ControleAcesso ControleAcesso { get; set; }

        public Empresa Empresa { get; set; }

        public Loja Loja { get; set; }

        public IEnumerable<SelectListItem> EmpresasSelectListItem { get; set; }

        public IEnumerable<SelectListItem> LojasSelectListItem { get; set; }

        public InterfaceFolhaPagamentoViewModel(string codigoFolha, string codigoClienteADP, IEnumerable<SelectListItem> empresasSelectListItem, IEnumerable<SelectListItem> lojasSelectListItem)
        {
            CodigoFolha = codigoFolha;
            CodigoClienteADP = codigoClienteADP;
            EmpresasSelectListItem = empresasSelectListItem;
            LojasSelectListItem = lojasSelectListItem;
        }


    }
}