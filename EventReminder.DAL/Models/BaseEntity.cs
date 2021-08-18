using EventReminder.DAL.Abstractions;
using System;

namespace EventReminder.DAL.Models
{
    public abstract class BaseEntity: IBaseEntity
    {
        public Guid Id
        {
            get;
            set;
        }
    }
}
