using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventOrganizer.Events
{
    public class CreateUpdateEventDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public EventType Type { get; set; } = EventType.Union;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string Location { get; set; }

        public int OrganizerId { get; set; }
    }
}
