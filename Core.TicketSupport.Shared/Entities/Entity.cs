using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TicketSupport.Shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = new Guid();
        }

        public Guid Id { get; private set; }
    }
}
