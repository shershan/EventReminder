using EventReminder.DAL.Extensions;
using EventReminder.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventReminder.DAL
{
    public class EventNotificationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public EventNotificationDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMap().Build(modelBuilder.Entity<User>());
            new EventMap().Build(modelBuilder.Entity<Event>());
            new NotificationMap().Build(modelBuilder.Entity<Notification>());
        }

    }
}
