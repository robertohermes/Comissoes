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
            Mapper.CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}