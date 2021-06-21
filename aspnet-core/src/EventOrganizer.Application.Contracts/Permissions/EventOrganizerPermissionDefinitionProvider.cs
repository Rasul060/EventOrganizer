using EventOrganizer.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EventOrganizer.Permissions
{
    public class EventOrganizerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var eventOrganizerGroup = context.AddGroup(EventOrganizerPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(EventOrganizerPermissions.MyPermission1, L("Permission:MyPermission1"));
            var eventsPermission = eventOrganizerGroup.AddPermission(EventOrganizerPermissions.Events.Default, L("Permission:Events"));
            eventsPermission.AddChild(EventOrganizerPermissions.Events.Create, L("Permission:Events.Create"));
            eventsPermission.AddChild(EventOrganizerPermissions.Events.Edit, L("Permission:Events.Edit"));
            eventsPermission.AddChild(EventOrganizerPermissions.Events.Delete, L("Permission:Events.Delete"));

            var organizersPermission = eventOrganizerGroup.AddPermission(
    EventOrganizerPermissions.Organizers.Default, L("Permission:Organizers"));

            eventsPermission.AddChild(
                EventOrganizerPermissions.Organizers.Create, L("Permission:Organizers.Create"));

            eventsPermission.AddChild(
                EventOrganizerPermissions.Organizers.Edit, L("Permission:Organizers.Edit"));

            eventsPermission.AddChild(
                EventOrganizerPermissions.Organizers.Delete, L("Permission:Organizers.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EventOrganizerResource>(name);
        }
    }
}
