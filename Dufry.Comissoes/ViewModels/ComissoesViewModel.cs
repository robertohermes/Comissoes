using Dufry.Comissoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class ComissoesViewModel
    {
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

        public Produto Item { get; set; }

        public ProdutoCategoria ProdutoCategoria { get; set; }

        //public ProdutoGrupoDufry ProdutoGrupoDufry { get; set; }

        public ProdutoSubGrupoDufry ProdutoSubGrupoDufry { get; set; }

        public TipoBusiness TipoBusiness { get; set; }
        
        public Aeroporto Aeroporto { get; set; }

        public ControleAcesso ControleAcesso { get; set; }

        public Cargo Cargo { get; set; }

        public Loja Loja { get; set; }


        public IEnumerable<SelectListItem> ColaboradoresSelectListItem { get; set; }

        public IEnumerable<SelectListItem> CargosSelectListItem { get; set; }

        public IEnumerable<SelectListItem> ItensSelectListItem { get; set; }

        public IEnumerable<SelectListItem> SubGruposDufrySelectListItem { get; set; }

        public IEnumerable<SelectListItem> GruposDufrySelectListItem { get; set; }

        public IEnumerable<SelectListItem> ProdutoCategoriasSelectListItem { get; set; }

        public IEnumerable<SelectListItem> TipoBusinesesSelectListItem { get; set; }

        public IEnumerable<SelectListItem> LojasSelectListItem { get; set; }

        public IEnumerable<SelectListItem> AeroportosSelectListItem { get; set; }


        public ComissoesViewModel(IEnumerable<SelectListItem> colaboradoresSelectListItem, IEnumerable<SelectListItem> lojasSelectListItem, IEnumerable<SelectListItem> itensSelectListItem, IEnumerable<SelectListItem> tipobusinesesSelectListItem, IEnumerable<SelectListItem> cargosSelectListItem, IEnumerable<SelectListItem> aeroportosSelectListItem, IEnumerable<SelectListItem> subGruposDufrySelectListItem, IEnumerable<SelectListItem> produtoCategoriasSelectListItem)
        {
            ColaboradoresSelectListItem = colaboradoresSelectListItem;
            LojasSelectListItem = lojasSelectListItem;
            ItensSelectListItem = itensSelectListItem;
            TipoBusinesesSelectListItem = tipobusinesesSelectListItem;
            CargosSelectListItem = cargosSelectListItem;
            AeroportosSelectListItem = aeroportosSelectListItem;
            SubGruposDufrySelectListItem = subGruposDufrySelectListItem;
            ProdutoCategoriasSelectListItem = produtoCategoriasSelectListItem;
        }


    }
}