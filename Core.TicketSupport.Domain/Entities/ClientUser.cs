using Core.TicketSupport.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TicketSupport.Domain.Entities
{
    public class ClientUser : User
    {
        public ClientUser(Name name, Email email, string clienteToken, string company, string callNumber) 
            : base(name, email)
        {
            ClienteToken = clienteToken;
            Company = company;
            CallNumber = callNumber;
        }

        public string ClienteToken { get; private set; }

        public string Company { get; private set; }

        public string CallNumber { get; private set; }
    }
}
