using Flunt.Notifications;
using System;

namespace Core.TicketSupport.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
    }
}
