using Flunt.Notifications;
using System;

namespace Core.TicketSupport.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = 0;
        }

        public int Id { get; private set; }
    }
}
