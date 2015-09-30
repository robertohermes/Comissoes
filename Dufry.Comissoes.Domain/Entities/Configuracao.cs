using System;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Configuracao
    {
        public int ID_CONFIGURACAO { get; set; }
        public string DESC_CHAVE { get; set; }
        public string DESC_VALOR { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

    }
}
