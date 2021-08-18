using EventBuilder.Constants;
using EventReminder.Models.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EventReminder.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventNotificationDbContext>
    {
        public EventNotificationDbContext CreateDbContext(string[] args)
        {
            var configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(ConfigurationConstants.AppSettingsFileName)
                    .Build();

            var settings = new DbSettings();
            configuration.GetSection(ConfigurationConstants.DBSectionName).Bind(settings);

            var builder = new DbContextOptionsBuilder<EventNotificationDbContext>();
            builder.UseSqlServer(settings.DefaultConnection, b => b.MigrationsAssembly(settings.MigrationAsseblyName));

            return new EventNotificationDbContext(builder.Options);
        }
    }
}
