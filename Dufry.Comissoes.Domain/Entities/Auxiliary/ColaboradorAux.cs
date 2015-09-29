using System;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities.Auxiliary
{
    public class ColaboradorAux
    {
        public string CODIGOSECUNDARIO { get; set; }

        public string CODIGOEMPRESAALTERNATE { get; set; }

        public string CODIGOFILIALALTERNATE { get; set; }

        public string NomeCompleto { get; set; }

    }
}
