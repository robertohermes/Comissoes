using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;


namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Colaborador
    {
        public int Id_Colaborador { get; set; }
        public int Id_Loja { get; set; }
        public int Id_Cargo { get; set; }
        public string CodigoSecundario { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime ? DataAdmissao { get; set; }
        public DateTime ? DataNascimento { get; set; }
        public string  Email { get; set; }
        public string  Genero { get; set; }
        public decimal ? Comissao { get; set; }

    }
}
