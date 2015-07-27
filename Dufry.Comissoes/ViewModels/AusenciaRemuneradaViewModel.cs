using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class AusenciaRemuneradaViewModel
    {
        public string Name { get; set; }

        public static AusenciaRemuneradaViewModel ToViewModel(AusenciaRemunerada ausenciaremunerada)
        {
            return Mapper.Map<AusenciaRemuneradaViewModel>(ausenciaremunerada);
        }
    }
}