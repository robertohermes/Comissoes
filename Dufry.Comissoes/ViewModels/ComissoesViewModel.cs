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

        //<TODO> Classes que serão necessárias
        //public Produto { get; set; }
        //public ProdutoSubGrupo { get; set; }
        //public ProdutoGrupo { get; set; }
        //public ProdutoSegmento { get; set; }
        //public TipoBusiness { get; set; }
        //public Aeroporto { get; set; }
        //public TipoNegocio { get; set; }

        public ControleAcesso ControleAcesso { get; set; }

        public Cargo Cargo { get; set; }

        public Loja Loja { get; set; }


        public IEnumerable<SelectListItem> ColaboradoresSelectListItem { get; set; }

        public IEnumerable<SelectListItem> CargosSelectListItem { get; set; }

        public IEnumerable<SelectListItem> ItensSelectListItem { get; set; }

        public IEnumerable<SelectListItem> SubGruposSelectListItem { get; set; }

        public IEnumerable<SelectListItem> GruposSelectListItem { get; set; }

        public IEnumerable<SelectListItem> SegmentosSelectListItem { get; set; }

        public IEnumerable<SelectListItem> TipoBusinessesSelectListItem { get; set; }

        public IEnumerable<SelectListItem> LojasSelectListItem { get; set; }

        public IEnumerable<SelectListItem> AeroportosSelectListItem { get; set; }


        public ComissoesViewModel(IEnumerable<SelectListItem> colaboradoresSelectListItem, IEnumerable<SelectListItem> lojasSelectListItem)
        {
            ColaboradoresSelectListItem = colaboradoresSelectListItem;
            LojasSelectListItem = lojasSelectListItem;
        }


    }
}