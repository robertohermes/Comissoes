using System;
using System.ComponentModel.DataAnnotations;
//using AutoMapper;

namespace Dufry.Comissoes.ViewModels
{
    public class InterfaceTransferPricingViewModel
    {
        [Required(ErrorMessage = "A data inicial é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "A data inicial está em formato inválido")]
        [Display(Name = "Data inicial")]
        public DateTime DT_INI { get; set; }


        [Required(ErrorMessage = "A data final é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "A data final está em formato inválido")]
        [Display(Name = "Data final")]
        public DateTime DT_FIM { get; set; }


        public InterfaceTransferPricingViewModel()
        {
        }


    }
}