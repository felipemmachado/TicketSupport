using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Shared.Entities;
using Flunt.Validations;
using System;

namespace Core.TicketSupport.Domain.Entities
{
    public class Historic : Entity
    {
        public Historic(InternalUser responsable, 
                        ClientUser client, 
                        string description, 
                        EHistoricInteractionType interaction)
        {
            Responsable = responsable;
            Client = client;
            Description = description;
            InsertDate = DateTime.UtcNow;
            Interaction = interaction;

            AddNotifications(responsable, 
                client, 
                new Contract()
                .Requires()
                .HasMinLen(Description, 3, "Historic.Description", "A descrição não pode ser vazia.")
                .IsNotNull(Interaction, "Historic.Interaction", "O tipo da interação é obrigatória."));
        }

        public InternalUser Responsable { get; private set; }

        public ClientUser Client { get; private set; }

        public string Description { get; private set; }

        public DateTime InsertDate { get; private set; }

        public EHistoricInteractionType Interaction { get; private set; }
    }
}
