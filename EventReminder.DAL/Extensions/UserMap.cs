using EventBuilder.Constants;
using EventReminder.DAL.Maps;
using EventReminder.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EventReminder.DAL.Extensions
{
    internal class UserMap : BaseMap<User>
    {
        protected internal override string SchemaName
        {
            get => DbTables.Identity;
        }

        protected override void Configure(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.AddBase();
        }
    }
}
