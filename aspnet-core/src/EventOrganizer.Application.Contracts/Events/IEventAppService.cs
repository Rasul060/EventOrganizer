using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EventOrganizer.Events
{
    public interface IEventAppService:
        ICrudAppService< //Defines CRUD methods
            EventDto, //Used to show books
            int, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateEventDto,
            UpdateEventDto> //Used to create a book
  //Used to update a book
    {
        Task<ListResultDto<OrganizerLookupDto>> GetOrganizerLookupAsync();
    }
}
