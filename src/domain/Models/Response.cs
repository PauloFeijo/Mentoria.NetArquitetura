using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Response<TData>
    {
        public Response(TData data, IEnumerable<Notification> notifications = null)
        {
            _data = data;
            _notifications = notifications;
        }

        public TData Data => _data;
        public bool IsValid => Data != null && (_notifications is null || !_notifications.Any());
        public IEnumerable<Notification> Notifications => _notifications;

        private readonly TData _data;
        private readonly IEnumerable<Notification> _notifications;
    }
}
