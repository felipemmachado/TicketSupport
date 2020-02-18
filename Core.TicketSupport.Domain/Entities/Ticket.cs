using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Shared.Entities;
using System;
using System.Collections.Generic;

namespace Core.TicketSupport.Domain.Entities
{
    public class Ticket : Entity
    {
        public Ticket(string title, ETicketStatusType status, EPriorityType priority, ClientUser client)
        {
            Title = title;
            Status = status;
            Priority = priority;
            Client = client;
            OpenDate = DateTime.UtcNow;
            _historics = new List<Historic>();
        }

        public string Code { get; private set; }

        public string Title { get; private set; }

        public ETicketStatusType Status { get; private set; }

        public EPriorityType Priority { get; private set; }

        public DateTime OpenDate { get; private set; }

        public DateTime? CloseDate { get; private set; }

        public DateTime? ForecastDate { get; private set; }

        public DateTime? DevelopmentConclusionDate { get; private set; }

        public ClientUser Client { get; private set; }

        public InternalUser Responsable { get; private set; }

        public IReadOnlyList<Historic> Historics { get; private set; }

        private IList<Historic> _historics { get; set; }
    }
}
