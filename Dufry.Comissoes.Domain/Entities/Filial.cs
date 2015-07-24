using System.Collections.Generic;
using Dufry.Comissoes.Domain.Entities.Validations;
using Dufry.Comissoes.Domain.Interfaces.Validation;
using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class Filial
    {
        public int Id_Filial { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Cidade { get; set; }
        public string CodigoFilialAlternate { get; set; }
        public string NomeFilial { get; set; }
    }
}
