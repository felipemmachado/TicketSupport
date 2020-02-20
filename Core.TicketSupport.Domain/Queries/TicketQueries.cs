using Core.TicketSupport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.TicketSupport.Domain.Queries
{
    public static class TicketQueries
    {
        public static Expression<Func<Ticket, bool>> GetTicketByCode(string code)
        {
            return x => x.Code == code;
        }

        public static Expression<Func<Ticket, bool>> GetTicketByClientId(int clientId)
        {
            return x => x.Client.ClientId == clientId;
        }
    }
}
