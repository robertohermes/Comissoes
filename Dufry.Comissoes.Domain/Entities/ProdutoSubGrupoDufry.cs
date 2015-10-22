using System;
using System.ComponentModel.DataAnnotations;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class ProdutoSubGrupoDufry
    {
        public int Id_ProdutoSubGrupoDufry { get; set; }
        public int Id_ProdutoGrupoDufry { get; set; }
        public int Id_ProdutoCategoria { get; set; }
        public string CodigoProdutoSubGrupoDufryAlternate { get; set; }
        public string NomeProdutoSubGrupoDufry { get; set; }

    }
}
