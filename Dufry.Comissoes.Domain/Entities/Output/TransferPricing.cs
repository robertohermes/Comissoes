using System;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class TransferPricing
    {
        public string COD_PRODUTO { get; set; }
        public string NEGOCIO { get; set; }
        public DateTime MES { get; set; }
        public decimal VLR_DOLAR { get; set; }
        public decimal VLR_REAL { get; set; }
        public string COD_EMPRESA { get; set; }
    }
}
