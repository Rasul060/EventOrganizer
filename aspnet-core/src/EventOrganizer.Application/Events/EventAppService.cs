using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using EventOrganizer.Organizers;
using EventOrganizer.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace EventOrganizer.Events
{
    //[Authorize(EventOrganizerPermissions.Events.Default)]
    public class EventAppService :
        CrudAppService<
            Event, //The Book entity
            EventDto, //Used to show books
            int, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateEventDto,
            UpdateEventDto>, //Used to create/update a book
        IEventAppService //implement the IBookAppService
    {
        private readonly IOrganizerRepository _organizerRepository;

        public EventAppService(IRepository<Event, int> repository,IOrganizerRepository organizerRepository) : base(repository)
        {
            _organizerRepository = organizerRepository;
            GetPolicyName = EventOrganizerPermissions.Events.Default;
            GetListPolicyName = EventOrganizerPermissions.Events.Default;
            CreatePolicyName = EventOrganizerPermissions.Events.Create;
            UpdatePolicyName = EventOrganizerPermissions.Events.Edit;
            DeletePolicyName = EventOrganizerPermissions.Events.Create;
        }

        public override async Task<EventDto> GetAsync(int id)
        {
            //Get the IQueryable<Book> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join books and authors
            var query = from book in queryable
                        join author in _organizerRepository on book.OrganizerId equals author.Id
                        where book.Id == id
                        select new { book, author };

            //Execute the query and get the book with author
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Event), id);
            }

            var bookDto = ObjectMapper.Map<Event, EventDto>(queryResult.book);
            bookDto.OrganizerName = queryResult.author.Name;
            return bookDto;
        }

        public override async Task<PagedResultDto<EventDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
           
                var queryable = await Repository.GetQueryableAsync();

                //Prepare a query to join books and authors
                var query = from book in queryable
                            join author in _organizerRepository on book.OrganizerId equals author.Id
                            select new { book, author };

                //Paging
                query = query
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount);

                //Execute the query and get a list
                var queryResult = await AsyncExecuter.ToListAsync(query);
               
                var bookDtos = queryResult.Select(x =>
                {
                    var bookDto = ObjectMapper.Map<Event, EventDto>(x.book);
                    bookDto.OrganizerName = x.author.Name;
                    return bookDto;
                }).ToList();

                var totalCount = await Repository.GetCountAsync();

                return new PagedResultDto<EventDto>(
                    totalCount,
                    bookDtos
                );
           
            
        }

        public async Task<ListResultDto<OrganizerLookupDto>> GetOrganizerLookupAsync()
        {
            var organizers = await _organizerRepository.GetListAsync();

            return new ListResultDto<OrganizerLookupDto>(
                ObjectMapper.Map<List<Organizer>, List<OrganizerLookupDto>>(organizers)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"event.{nameof(Event.Name)}";
            }

            if (sorting.Contains("organizerName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "organizerName",
                    "organizer.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"event.{sorting}";
        }

    }
}
