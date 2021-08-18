using EventReminder.DAL.Abstractions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace EventReminder.DAL.Models
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public virtual IList<Event> Events
        {
            get;
            set;
        }
    }
}
