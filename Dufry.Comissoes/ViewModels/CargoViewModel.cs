using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class CargoViewModel
    {
        public int Id_Cargo { get; set; }
        public string CodigoCargoAlternate { get; set; }
        public string NomeCargo { get; set; }

        public CargoViewModel ToViewModel(Cargo cargo)
        {
            return Mapper.Map<CargoViewModel>(cargo);
        }
    }
}