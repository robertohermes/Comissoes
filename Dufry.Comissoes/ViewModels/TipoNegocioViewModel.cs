using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class TipoNegocioViewModel
    {
        public int Id_TipoNegocio { get; set; }
        public int Id_TipoBusiness { get; set; }
        public int Id_Empresa { get; set; }
        public string CodigoEmpresaLegado { get; set; }
        public string CodigoTipoNegocioAlternate { get; set; }
        public string NomeTipoNegocio { get; set; }

        //public TipoNegocioViewModel ToViewModel(TipoNegocioViewModel tiponegocio)
        //{
        //    return Mapper.Map<LojaViewModel>(tiponegocio);
        //}
    }
}