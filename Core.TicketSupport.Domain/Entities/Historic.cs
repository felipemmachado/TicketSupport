using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Domain.ValueObjects;
using Core.TicketSupport.Shared.Entities;
using Flunt.Validations;
using System;

namespace Core.TicketSupport.Domain.Entities
{
    public class Historic : Entity
    {
        public Historic(Name name, 
                        Email email, 
                        string description, 
                        EHistoricInteractionType interaction)
        {
            
            Email = email;
            Name = name;
            Description = description;
            InsertDate = DateTime.UtcNow;
            Interaction = interaction;

            AddNotifications(Email,
                Name, 
                new Contract()
                .Requires()
                .HasMinLen(Description, 3, "Historic.Description", "A descrição não pode ser vazia.")
                .IsNotNull(Interaction, "Historic.Interaction", "O tipo da interação é obrigatória."));
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Description { get; private set; }
        public DateTime InsertDate { get; private set; }
        public EHistoricInteractionType Interaction { get; private set; }
    }
}
