using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BaseApi.Api.Responses
{
    public class ResponseResult : Notifiable
    {

        public ResponseResult(object data)
        {

            if (data is Notifiable)
            {
                AddNotifications(data as Notifiable);
            }

            Object = data;
        }

        public ResponseResult(object data, Notifiable notifiable)
        {
            Object = data;
            AddNotifications(notifiable);
        }

        public ResponseResult(object data, IEnumerable<Notification> notifications)
        {
            Object = data;
            notifications.ToList().ForEach(n => AddNotification(n));
        }
        public bool Success => Valid;
        public object Object { get; private set; }

    }

    public class ResponseResult<TEntityResult> : Notifiable
        where TEntityResult : Notifiable
    {
        public ResponseResult(TEntityResult data)
        {

            AddNotifications(data);

            Object = data;
        }

        public ResponseResult(TEntityResult data, Notifiable notifiable)
        {
            Object = data;
            AddNotifications(data);
            AddNotifications(notifiable);
        }

        public ResponseResult(TEntityResult data, IEnumerable<Notification> notifications)
        {
            Object = data;
            notifications.ToList().ForEach(n => AddNotification(n));
        }
        public bool Success => Valid;
        public TEntityResult Object { get; private set; }
    }
}
