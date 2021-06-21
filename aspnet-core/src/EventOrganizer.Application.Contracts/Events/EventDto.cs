using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EventOrganizer.Events
{
    public class EventDto : AuditedEntityDto<int>
    {
        public string Name { get; set; }

        public EventType Type { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        public int OrganizerId { get; set; }
        public string OrganizerName { get; set; }
    }
}
