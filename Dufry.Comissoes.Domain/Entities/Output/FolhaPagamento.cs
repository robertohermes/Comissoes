using System;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class FolhaPagamento
    {
        public string COD_FOLHA { get; set; }
        public string COD_EMPRESA { get; set; }
        public string MATRICULA { get; set; }
        public string COD_CLIENTE { get; set; }
        public string PROCESSO_FOLHA { get; set; }
        public decimal VALOR_LANCAMENTO { get; set; }
    }
}
