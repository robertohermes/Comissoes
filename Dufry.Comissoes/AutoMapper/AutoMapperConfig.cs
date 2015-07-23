using AutoMapper;

namespace Dufry.Comissoes.AutoMapper
{
    public class AutoMapperConfig
    {        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
