using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Shared.Entities;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

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

            // Adiciona as notificações de validação dos value Objects
            AddNotifications(client, 
                    new Contract()
                    .Requires()
                    .HasMinLen(Title, 5, "Ticket.Title", "O título é obrigatório"));
        }

        public string Code { get; private set; }

        public string Title { get; private set; }

        public ETicketStatusType Status { get; private set; }

        public EPriorityType Priority { get; private set; }

        public DateTime OpenDate { get; private set; }

        public DateTime? ConclusionDate { get; private set; }

        public DateTime? ForecastDate { get; private set; }

        public DateTime? DevelopmentConclusionDate { get; private set; }

        public ClientUser Client { get; private set; }

        public InternalUser Responsable { get; private set; }

        public IReadOnlyList<Historic> Historics { get { return _historics.ToArray(); } }

        private IList<Historic> _historics { get; set; }

        public void AddHistoric(Historic historic)
        {
            if (historic == null)
                AddNotification("Ticket.Historic", "O histórico não pode ser null");

            _historics.Add(historic);
        }

        public void SetForecastDate(DateTime forecastDate)
        {
            if (forecastDate <= DateTime.UtcNow)
                AddNotification("Ticket.ForecastDate", "A data de previsão não pode ser menor que agora");

            ForecastDate = forecastDate;
        }

        public void ChangeStatus(ETicketStatusType ticketStaus)
        {
            Status = ticketStaus;
        }

        public void ChangeResponsable(InternalUser internalUser)
        {

            if (internalUser == null)
                AddNotification("Ticket.Responsable", "O Responsável não pode ser null");

            Responsable = internalUser;
        }

        public void Conclude(DateTime conclusionDate)
        {
            if (conclusionDate <=  DateTime.UtcNow)
                AddNotification("Ticket.ForecastDate", "A data de conclusão não pode ser menor que agora");

            ConclusionDate = conclusionDate;
        }
    }
}
