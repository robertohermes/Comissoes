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
    public partial class Cargo
    {
        public int Id_Cargo { get; set; }

        public string CodigoCargoAlternate { get; set; }

        [Display(Name = "Nome do Cargo")]
        public string NomeCargo { get; set; }

    }
}
