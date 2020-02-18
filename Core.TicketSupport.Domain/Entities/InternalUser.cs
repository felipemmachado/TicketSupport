using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Domain.ValueObjects;

namespace Core.TicketSupport.Domain.Entities
{
    public class InternalUser : User
    {
        public InternalUser(Name name, Email email, EAccessLevelType accessLevel) 
            : base(name, email)
        {
            AccessLevel = accessLevel;
        }

        public EAccessLevelType AccessLevel { get; private set; }
    }
}
