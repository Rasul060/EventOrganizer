using Volo.Abp;

namespace EventOrganizer.Organizers
{
    public class OrganizerAlreadyExistsException : BusinessException
    {
        public OrganizerAlreadyExistsException(string name)
            : base(EventOrganizerDomainErrorCodes.OrganizerAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
