using AutoMapper;
using Dufry.Comissoes.Domain.Entities;

namespace Dufry.Comissoes.ViewModels
{
    public class EmpresaViewModel
    {
        public int Id_Empresa { get; set; }
        public int Id_TipoNegocio { get; set; }
        public int Id_Pais { get; set; }
        public int Id_TipoRegimeAduaneiro { get; set; }
        public string CodigoEmpresaAlternate { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeReduzido { get; set; }


        public static EmpresaViewModel ToViewModel(Empresa empresa)
        {
            return Mapper.Map<EmpresaViewModel>(empresa);
        }
    }
}