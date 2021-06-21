using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventOrganizer.Events
{
    public class UpdateEventDto
    {
       
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; } 

        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; } 

        [StringLength(100)]
        public string Location { get; set; }
    }
}
