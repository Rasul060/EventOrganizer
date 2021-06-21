using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using EventOrganizer.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EventOrganizer.Organizers
{
    public class EfCoreOrganizerRepository
        : EfCoreRepository<EventOrganizerDbContext, Organizer, int>,
            IOrganizerRepository
    {
        public EfCoreOrganizerRepository(
            IDbContextProvider<EventOrganizerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Organizer> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(organizer => organizer.Name == name);
        }

        public async Task<List<Organizer>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    organizer => organizer.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
