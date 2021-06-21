using System;
using Volo.Abp.Application.Dtos;

namespace EventOrganizer.Organizers
{
    public class OrganizerDto : EntityDto<int>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}
