using System;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class DSRSearch
    {
        public int ID_DSR { get; set; }
        public string CODIGOLOJAALTERNATE { get; set; }
        public decimal PERCENTUAL { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_INI { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_FIM { get; set; }

        public string STATUS { get; set; }

        public Loja Loja { get; set; }
    }
}
