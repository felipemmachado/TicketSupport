using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

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
