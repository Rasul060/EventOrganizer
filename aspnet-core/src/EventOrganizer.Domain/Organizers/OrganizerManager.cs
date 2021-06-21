using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace EventOrganizer.Organizers
{
    public class OrganizerManager : DomainService
    {
        private readonly IOrganizerRepository _organizerRepository;

        public OrganizerManager(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }

        public async Task<Organizer> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingOrganizer = await _organizerRepository.FindByNameAsync(name);
            if (existingOrganizer != null)
            {
                throw new OrganizerAlreadyExistsException(name);
            }

            return new Organizer(
                name,
                birthDate,
                shortBio 
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Organizer organizer,
            [NotNull] string newName)
        {
            Check.NotNull(organizer, nameof(organizer));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingOrganizer = await _organizerRepository.FindByNameAsync(newName);
            if (existingOrganizer != null && existingOrganizer.Id != organizer.Id)
            {
                throw new OrganizerAlreadyExistsException(newName);
            }

            organizer.ChangeName(newName);
        }
    }
}
