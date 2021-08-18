using System;
using System.Collections.Generic;

namespace EventReminder.DAL.Models
{
    public class Event: BaseEntity
    {
        public virtual User User
        {
            get;
            set;
        }

        public virtual IList<Notification> Notifications
        {
            get;
            set;
        }

        public Guid UserId
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public bool WithYear
        {
            get;
            set;
        }
    }
}
