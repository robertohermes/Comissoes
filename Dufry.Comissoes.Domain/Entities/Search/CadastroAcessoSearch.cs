using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class CadastroAcessoSearch
    {
        public int COLABORADORKEY { get; set; }

        public int ? COLABORADORKEY_PAI { get; set; }

        public string CODIGOSECUNDARIO { get; set; }

        public string CODIGOEMPRESAALTERNATE { get; set; }

        public string CODIGOFILIALALTERNATE { get; set; }

        public string LOGIN { get; set; }

        public string ADMIN { get; set; }

        public string STATUS { get; set; }

        public string NomeCompleto { get; set; }

        public string NomeSuperiorCompleto { get; set; }

    }
}
