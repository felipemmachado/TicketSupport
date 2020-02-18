using Core.TicketSupport.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TicketSupport.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
