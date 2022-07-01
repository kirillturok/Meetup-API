using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Model;

namespace Modsen
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventForCreationDto, Event>();
            CreateMap<EventForUpdateDto, Event>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
