using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventOrganizer.Organizers;
using EventOrganizer.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace EventOrganizer.Organizers
{
    //[Authorize(EventOrganizerPermissions.Organizers.Default)]
    public class OrganizerAppService : EventOrganizerAppService, IOrganizerAppService
    {
        private readonly IOrganizerRepository _organizerRepository;
        private readonly OrganizerManager _organizerManager;

        public OrganizerAppService(
            IOrganizerRepository organizerRepository,
            OrganizerManager organizerManager)
        {
            _organizerRepository = organizerRepository;
            _organizerManager = organizerManager;
        }
                                    
        //...SERVICE METHODS WILL COME HERE...
        public async Task<OrganizerDto> GetAsync(int id) 
        {
            var organizer = await _organizerRepository.GetAsync(id);
            return ObjectMapper.Map<Organizer, OrganizerDto>(organizer);
        }

        public async Task<PagedResultDto<OrganizerDto>> GetListAsync(GetOrganizerListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Organizer.Name);
            }

            var organizers = await _organizerRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _organizerRepository.CountAsync()
                : await _organizerRepository.CountAsync(
                    organizer => organizer.Name.Contains(input.Filter));

            return new PagedResultDto<OrganizerDto>(
                totalCount,
                ObjectMapper.Map<List<Organizer>, List<OrganizerDto>>(organizers)
            );
        }

        //[Authorize(EventOrganizerPermissions.Organizers.Create)]
        public async Task<OrganizerDto> CreateAsync(CreateOrganizerDto input)
        {
            var organizer = await _organizerManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.ShortBio
            );

            await _organizerRepository.InsertAsync(organizer);

            return ObjectMapper.Map<Organizer, OrganizerDto>(organizer);
        }

        //[Authorize(EventOrganizerPermissions.Organizers.Edit)]
        public async Task UpdateAsync(int id, UpdateOrganizerDto input)
        {
            var organizer = await _organizerRepository.GetAsync(id);

            if (organizer.Name != input.Name)
            {
                await _organizerManager.ChangeNameAsync(organizer, input.Name);
            }

            organizer.BirthDate = input.BirthDate;
            organizer.ShortBio = input.ShortBio;

            await _organizerRepository.UpdateAsync(organizer);
        }

        //[Authorize(EventOrganizerPermissions.Organizers.Delete)]
        public async Task DeleteAsync(int id)
        {
            await _organizerRepository.DeleteAsync(id);
        }







    }
}
