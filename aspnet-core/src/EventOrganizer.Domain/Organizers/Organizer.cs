using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace EventOrganizer.Organizers
{
    public class Organizer : FullAuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio { get; set; }

        public Organizer()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Organizer(
            [System.Diagnostics.CodeAnalysis.NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string shortBio = null) 
            : base()
        {
            SetName(name);
            BirthDate = birthDate;
            ShortBio = shortBio;
        }

        public Organizer ChangeName([System.Diagnostics.CodeAnalysis.NotNull] string name)
        {
            SetName(name);
            return this;
        }

        public void SetName([System.Diagnostics.CodeAnalysis.NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: OrganizerConsts.MaxNameLength
            );
        }
    }
}
