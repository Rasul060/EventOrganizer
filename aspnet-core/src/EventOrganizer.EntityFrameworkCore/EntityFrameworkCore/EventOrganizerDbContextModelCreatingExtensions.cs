using EventOrganizer.Events;
using EventOrganizer.Organizers;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EventOrganizer.EntityFrameworkCore
{
    public static class EventOrganizerDbContextModelCreatingExtensions
    {
        public static void ConfigureEventOrganizer(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Event>(b =>
            {
                b.ToTable(EventOrganizerConsts.DbTablePrefix + "Books",
                          EventOrganizerConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(50);
                b.Property(x => x.Date).IsRequired();
                b.Property(x => x.Location).HasMaxLength(100);

                b.HasOne<Organizer>().WithMany().HasForeignKey(x => x.OrganizerId).IsRequired();
            });

            builder.Entity<Organizer>(b =>
            {
                b.ToTable(EventOrganizerConsts.DbTablePrefix + "Organizers",
                    EventOrganizerConsts.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.Name).IsRequired().HasMaxLength(50);
                b.HasIndex(x => x.Name);
            });

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(EventOrganizerConsts.DbTablePrefix + "YourEntities", EventOrganizerConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}