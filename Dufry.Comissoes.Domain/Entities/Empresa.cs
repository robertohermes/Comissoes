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
    public partial class Empresa
    {
        public int Id_Empresa { get; set; }
        public int Id_TipoNegocio { get; set; }
        public int Id_Pais { get; set; }
        public int Id_TipoRegimeAduaneiro { get; set; }
        public string CodigoEmpresaAlternate { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeReduzido { get; set; }

    }
}
