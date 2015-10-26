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
    public partial class ProdutoGrupoDufry
    {
        public int Id_ProdutoGrupoDufry { get; set; }
        public int Id_ProdutoCategoria { get; set; }
        public string CodigoProdutoGrupoDufryAlternate { get; set; }
        public string NomeProdutoGrupoDufry { get; set; }
    }
}
