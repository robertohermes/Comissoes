using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Dufry.Comissoes.Domain.Entities.Search
{
    public partial class PlanoLojaSearch
    {
        public int ID_PLANO_LOJA { get; set; }
        public int ID_PLANO { get; set; }
        public string CODIGOLOJAALTERNATE { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_INI { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_FIM { get; set; }
        public string STATUS { get; set; }
        public Plano Plano { get; set; }
        public Loja Loja { get; set; }
    }
}
