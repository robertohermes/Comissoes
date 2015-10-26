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
    public partial class ProdutoCategoria
    {
        public int Id_ProdutoCategoria { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "A Categoria é obrigatória")]
        public string CodigoProdutoCategoriaAlternate { get; set; }

        public string NomeProdutoCategoria { get; set; }
    }
}
