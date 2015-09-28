using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class SelfServiceSearch
    {
        public int ID_SELF_SERVICE { get; set; }

        public string CODIGOCARGOALTERNATE { get; set; }

        public string CODIGOLOJAALTERNATE { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_INI { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_FIM { get; set; }

        public string STATUS { get; set; }

        public Cargo Cargo { get; set; }

        public Loja Loja { get; set; }

        

    }
}
