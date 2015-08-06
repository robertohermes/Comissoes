using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class LojaViewModel
    {
        public int Id_Loja { get; set; }
        public int Id_Filial { get; set; }
        public int Id_TipoLoja { get; set; }
        public int Id_Aeroporto { get; set; }
        public string CodigoLojaAlternate { get; set; }
        public string NomeLoja { get; set; }


        public LojaViewModel ToViewModel(Loja loja)
        {
            return Mapper.Map<LojaViewModel>(loja);
        }
    }
}