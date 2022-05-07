using AutoMapper;

namespace UuidMasterApi.Profiles
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<Entities.Resource, Models.ResourceDto>();
        }
    }
}
