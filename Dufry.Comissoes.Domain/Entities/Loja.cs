//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;
using System.ComponentModel.DataAnnotations;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Loja
    {
        public int Id_Loja { get; set; }
        public int Id_Filial { get; set; }
        public int Id_Grouping { get; set; }
        public int Id_DataOpen { get; set; }
        public int Id_DataClose { get; set; }
        public int Id_Cidade { get; set; }
        [Display(Name = "Nome da Loja")]
        public string CodigoLojaAlternate { get; set; }
        public string CodigoLojaLegado { get; set; }

        [Display(Name = "Nome da Loja")]
        public string NomeLoja { get; set; }
        public string NomeReduzido { get; set; }

    }
}
