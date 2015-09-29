﻿using Dufry.Comissoes.Domain.Entities.Auxiliary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dufry.Comissoes.Domain.Entities
{
    public partial class AusenciaRemuneradaSearch
    {
        public int ID_AUSENCIA_REMUNERADA { get; set; }

        public int COLABORADORKEY { get; set; }

        public string DESC_AUSENCIA { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_INI { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DT_FIM { get; set; }

        public string STATUS { get; set; }

        public ControleAcesso ControleAcesso { get; set; }

        public string NomeCompleto { get; set; }

    }
}
