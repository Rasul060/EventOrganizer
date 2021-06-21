using Volo.Abp.Application.Dtos;

namespace EventOrganizer.Organizers
{
    public class GetOrganizerListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
