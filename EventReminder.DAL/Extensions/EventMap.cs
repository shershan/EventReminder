using EventBuilder.Constants;
using EventReminder.DAL.Maps;
using EventReminder.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EventReminder.DAL.Extensions
{
    internal class EventMap : BaseMap<Event>
    {
        protected internal override string SchemaName
        {
            get => DbTables.Events;
        }

        protected override void Configure(EntityTypeBuilder<Event> entityBuilder)
        {
            entityBuilder.AddBase();

            entityBuilder
                .HasOne(x => x.User)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.UserId);
        }
    }
}
