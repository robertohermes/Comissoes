using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class LojaViewModel
    {
        public int Id_Loja { get; set; }
        public int Id_Filial { get; set; }
        public int Id_Grouping { get; set; }
        public int Id_DataOpen { get; set; }
        public int Id_DataClose { get; set; }
        public string CodigoLojaAlternate { get; set; }
        public string CodigoLojaLegado { get; set; }
        public string NomeLoja { get; set; }
        public string NomeReduzido { get; set; }

        public LojaViewModel ToViewModel(Loja loja)
        {
            return Mapper.Map<LojaViewModel>(loja);
        }
    }
}