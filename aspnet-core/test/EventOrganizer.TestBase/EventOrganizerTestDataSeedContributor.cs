using EventOrganizer.Organizers;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace EventOrganizer 
{
    public class EventOrganizerTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IOrganizerRepository _organizerRepository;

        public EventOrganizerTestDataSeedContributor(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            await _organizerRepository.InsertAsync(
                new Organizer
                {
                    Name = "Nabi",
                    BirthDate = new System.DateTime(2034, 4, 5),
                    ShortBio="salallalaal",
                    IsDeleted = false
                });

        }
    }
}