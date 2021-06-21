using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace EventOrganizer.Events
{
    public class Event : AuditedAggregateRoot<int>, ISoftDelete
    {
        public string Name { get; set; }

        public EventType Type { get; set; }

        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }

        public int OrganizerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
