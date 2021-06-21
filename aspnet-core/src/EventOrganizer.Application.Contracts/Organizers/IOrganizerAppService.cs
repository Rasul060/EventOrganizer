using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EventOrganizer.Organizers
{
    public interface IOrganizerAppService : IApplicationService
    {
        Task<OrganizerDto> GetAsync(int id);

        Task<PagedResultDto<OrganizerDto>> GetListAsync(GetOrganizerListDto input);

        Task<OrganizerDto> CreateAsync(CreateOrganizerDto input);

        Task UpdateAsync(int id, UpdateOrganizerDto input);

        Task DeleteAsync(int id);
    }
}
