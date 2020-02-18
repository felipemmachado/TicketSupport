using Core.TicketSupport.Domain.Enums;
using System;

namespace Core.TicketSupport.Domain.Entities
{
    public class Historic
    {
        public Historic(InternalUser responsable, ClientUser client, string description, DateTime insertDate, EHistoricInteractionType status)
        {
            Responsable = responsable;
            Client = client;
            Description = description;
            InsertDate = insertDate;
            Status = status;
        }

        public InternalUser Responsable { get; private set; }

        public ClientUser Client { get; private set; }

        public string Description { get; private set; }

        public DateTime InsertDate { get; private set; }

        public EHistoricInteractionType Status { get; private set; }
    }
}
