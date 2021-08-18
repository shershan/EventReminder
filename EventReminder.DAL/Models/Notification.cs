using System;

namespace EventReminder.DAL.Models
{
    public class Notification : BaseEntity
    {
        public Guid EventId
        {
            get;
            set;
        }

        public virtual Event Event
        {
            get;
            set;
        }

        public bool Viewed
        {
            get;
            set;
        }
    }
}
