using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Aeroporto
    {
        [Display(Name = "Aeroporto")]
        [Required(ErrorMessage = "O Aeroporto é obrigatório")]
        public int Id_Aeroporto { get; set; }
        public int Id_TipoNegocio { get; set; }
        public int Id_Filial { get; set; }

        [Display(Name = "Aeroporto")]
        public string SiglaAeroporto { get; set; }
    }
}
