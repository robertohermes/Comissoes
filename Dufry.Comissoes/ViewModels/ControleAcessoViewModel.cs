using System;
using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class ControleAcessoViewModel
    {
        public int COLABORADORKEY { get; set; }

        public int? COLABORADORKEY_PAI { get; set; }

        public string CODIGOSECUNDARIO { get; set; }

        public string CODIGOEMPRESAALTERNATE { get; set; }

        public string CODIGOFILIALALTERNATE { get; set; }

        public string LOGIN { get; set; }

        public string ADMIN { get; set; }

        public string STATUS { get; set; }
        public DateTime CREATED_DATETIME { get; set; }
        public string CREATED_USERNAME { get; set; }
        public DateTime LAST_MODIFY_DATE { get; set; }
        public string LAST_MODIFY_USERNAME { get; set; }

        public ControleAcessoViewModel ToViewModel(ControleAcesso controleacesso)
        {
            return Mapper.Map<ControleAcessoViewModel>(controleacesso);
        }
    }
}