using EventBuilder.Constants;
using EventReminder.DAL.Maps;
using EventReminder.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventReminder.DAL.Extensions
{
    internal class NotificationMap : BaseMap<Notification>
    {
        protected internal override string SchemaName
        {
            get => DbTables.Notification;
        }

        protected override void Configure(EntityTypeBuilder<Notification> entityBuilder)
        {
            entityBuilder.AddBase();

            entityBuilder
                .HasOne(x => x.Event)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.EventId);
        }
    }
}
