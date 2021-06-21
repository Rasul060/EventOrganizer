using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace EventOrganizer.Events
{
    public class OrganizerLookupDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
