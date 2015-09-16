using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class TipoNegocio
    {
        public int Id_TipoNegocio { get; set; }
        public int Id_TipoBusiness { get; set; }
        public int Id_Empresa { get; set; }
        public string CodigoEmpresaLegado { get; set; }
        public string CodigoTipoNegocioAlternate { get; set; }
        public string NomeTipoNegocio { get; set; }

    }
}
