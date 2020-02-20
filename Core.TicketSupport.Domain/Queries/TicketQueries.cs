using Core.TicketSupport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.TicketSupport.Domain.Queries
{
    public static class TicketQueries
    {
        public static Expression<Func<Ticket, bool>> GetTicketByCode(string code)
        {
            return x => x.Code == code;
        }
    }
}
