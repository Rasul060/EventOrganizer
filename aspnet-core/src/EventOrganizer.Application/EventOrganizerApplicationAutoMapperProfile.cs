using AutoMapper;
using EventOrganizer.Events;
using EventOrganizer.Organizers;

namespace EventOrganizer
{
    public class EventOrganizerApplicationAutoMapperProfile : Profile
    {
        public EventOrganizerApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Event, EventDto>();
            CreateMap<CreateUpdateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
            CreateMap<Organizer, OrganizerDto>();
            CreateMap<Organizer, OrganizerLookupDto>();
        }
    }
}
