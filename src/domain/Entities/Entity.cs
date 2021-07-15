using Flunt.Notifications;
using System;

namespace Domain.Entities
{
    public abstract class Entity : Notifiable<Notification>
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public string UpdatedBy { get; protected set; }
    }
}
