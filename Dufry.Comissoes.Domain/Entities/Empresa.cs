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
    public partial class Empresa
    {
        public int Id_Empresa { get; set; }

        public int Id_Pais { get; set; }

        [Display(Name = "Nome da Empresa")]
        [Required(ErrorMessage = "A Empresa é obrigatória")]
        public decimal CodigoEmpresaAlternate { get; set; }

        [Display(Name = "Nome da Empresa")]
        public string NomeEmpresa { get; set; }
    }
}
