using System;

namespace EventReminder.DAL.Abstractions
{
    public interface IBaseEntity
    {
        Guid Id
        {
            get;
            set;
        }
    }
}
