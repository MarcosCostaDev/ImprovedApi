using Flunt.Notifications;
using ImprovedApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImprovedApi.Api.Exceptions
{
    public class EntityException : BaseException<ImprovedEntity>
    {
        public EntityException(ImprovedEntity entity) : base(entity)
        {
        }

        public EntityException(Notifiable entity) : base(entity)
        {
        }


        public EntityException(IEnumerable<Notification> notifications) : base(notifications)
        {
        }

        
    }
}
