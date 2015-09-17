using AutoMapper;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.ViewModels;

namespace Dufry.Comissoes.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AusenciaRemunerada, AusenciaRemuneradaViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            Mapper.CreateMap<CategoriaPercentual, CategoriaPercentualViewModel>();
            Mapper.CreateMap<Colaborador, ColaboradorViewModel>();
            Mapper.CreateMap<ControleAcesso, CadastroAcessoViewModel>();
            Mapper.CreateMap<DolarMedio, DolarMedioViewModel>();
            Mapper.CreateMap<DSR, DSRViewModel>();
            Mapper.CreateMap<Empresa, EmpresaViewModel>();
            Mapper.CreateMap<Filial, FilialViewModel>();
            Mapper.CreateMap<Loja, LojaViewModel>();
            Mapper.CreateMap<Plano, PlanoViewModel>();
            Mapper.CreateMap<PlanoCategoria, PlanoCategoriaViewModel>();
            Mapper.CreateMap<SelfService, SelfServiceViewModel>();
            Mapper.CreateMap<Cargo, CargoViewModel>();
            Mapper.CreateMap<PlanoLoja, PlanoLojaViewModel>();
            Mapper.CreateMap<TipoNegocio, TipoNegocioViewModel>();
        }
    }
}