using Core.TicketSupport.Domain.ValueObjects;
using Core.TicketSupport.Shared.Entities;

namespace Core.TicketSupport.Domain.Entities
{
    public abstract class User : Entity
    {
        public User(Name name, Email email)
        {
            Name = name;
            Email = email;
        }

        public Name Name { get; private set; }

        public Email Email { get; private set; }
    }
}
