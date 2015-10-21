using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class TipoBusiness
    {
        public int Id_TipoBusiness { get; set; }
        [Display(Name = "Negócio")]
        [Required(ErrorMessage = "O Negócio é obrigatório")]
        public decimal CodigoTipoBusinessAlternate { get; set; }
        public string CodigoNegocio { get; set; }
        [Display(Name = "Negócio")]
        public string NomeTipoBusiness { get; set; }
    }
}
