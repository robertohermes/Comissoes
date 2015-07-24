//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Loja
    {
        public int Id_Loja { get; set; }
        public int Id_Filial { get; set; }
        public int Id_TipoLoja { get; set; }
        public int Id_Aeroporto { get; set; }
        public string CodigoLojaAlternate { get; set; }
        public string NomeLoja { get; set; }

    }
}
