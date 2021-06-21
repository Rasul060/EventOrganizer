using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EventOrganizer.Organizers
{
    public interface IOrganizerRepository : IRepository<Organizer, int>
    {
        Task<Organizer> FindByNameAsync(string name);

        Task<List<Organizer>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
