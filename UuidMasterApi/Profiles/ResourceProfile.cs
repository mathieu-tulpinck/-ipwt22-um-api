using AutoMapper;

namespace UuidMasterApi.Profiles
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<Entities.Resource, Models.ResourceDto>();
            CreateMap<Models.ResourceCreateDto, Entities.Resource>();
            CreateMap<Models.ResourceUpdateDto, Entities.Resource>();
            CreateMap<Entities.Resource, Models.ResourceUpdateDto>();
        }
    }
}
