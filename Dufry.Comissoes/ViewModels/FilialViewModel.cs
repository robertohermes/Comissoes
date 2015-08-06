using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class FilialViewModel
    {
        public int Id_Filial { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Cidade { get; set; }
        public string CodigoFilialAlternate { get; set; }
        public string NomeFilial { get; set; }


        public FilialViewModel ToViewModel(Filial filial)
        {
            return Mapper.Map<FilialViewModel>(filial);
        }
    }
}