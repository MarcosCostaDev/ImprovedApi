using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImprovedApi.Api.Exceptions
{
    public abstract class BaseException<T> : Exception where T : Notifiable
    {
        protected BaseException() { }
        public BaseException(T entity)
        {
            Notifications = entity.Notifications;
        }

        public BaseException(Notifiable entity)
        {
            Notifications = entity.Notifications;
        }

        public BaseException(IEnumerable<Notification> notifications)
        {
            Notifications = notifications;
        }

        public IEnumerable<Notification> Notifications { get; protected set; }

    }
}
