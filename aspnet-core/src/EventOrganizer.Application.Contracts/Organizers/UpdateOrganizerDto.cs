using System;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizer.Organizers
{
    public class UpdateOrganizerDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}
