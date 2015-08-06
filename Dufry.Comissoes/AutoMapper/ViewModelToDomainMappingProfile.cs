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
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}