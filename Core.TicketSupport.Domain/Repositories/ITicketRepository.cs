using Core.TicketSupport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TicketSupport.Domain.Repositories
{
    public interface ITicketRepository
    {
        void CreateTicket(Ticket ticket);

        void UpdateTicket(Ticket ticket);

        void AddHistoric(Ticket ticket, Historic historic);

    }
}
