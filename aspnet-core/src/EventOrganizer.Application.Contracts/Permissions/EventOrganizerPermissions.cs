namespace EventOrganizer.Permissions
{
    public static class EventOrganizerPermissions
    {
        public const string GroupName = "EventOrganizer";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
        public static class Events
        {
            public const string Default = GroupName + ".Events";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Organizers
        {
            public const string Default = GroupName + ".Organizers";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}