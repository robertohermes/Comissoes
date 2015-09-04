using AutoMapper;
using Dufry.Comissoes.Domain.Entities;
using Dufry.Comissoes.ViewModels;

namespace Dufry.Comissoes.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AusenciaRemuneradaViewModel, AusenciaRemunerada>();
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
            Mapper.CreateMap<CategoriaPercentualViewModel, CategoriaPercentual>();
            Mapper.CreateMap<ColaboradorViewModel, Colaborador>();
            Mapper.CreateMap<ControleAcessoViewModel, ControleAcesso>();
            Mapper.CreateMap<DolarMedioViewModel, DolarMedio>();
            Mapper.CreateMap<DSRViewModel, DSR>();
            Mapper.CreateMap<EmpresaViewModel, Empresa>();
            Mapper.CreateMap<FilialViewModel, Filial>();
            Mapper.CreateMap<LojaViewModel, Loja>();
            Mapper.CreateMap<PlanoViewModel, Plano>();
            Mapper.CreateMap<PlanoCategoriaViewModel, PlanoCategoria>();
            Mapper.CreateMap<SelfServiceViewModel, SelfService>();
            Mapper.CreateMap<CargoViewModel, Cargo>();
            Mapper.CreateMap<PlanoLojaViewModel, PlanoLoja>();
        }
    }
}