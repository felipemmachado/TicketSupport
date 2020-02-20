using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TicketSupport.Domain.Commands
{
    public class CreateTicketCommand : Notifiable, ICommand
    {
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientToken { get; set; }
        public string ClientCompany { get; set; }
        public string ClientCallNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ETicketStatusType Status { get; set; }
        public EPriorityType Priority { get; set; }
        public int ClientId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                        .Requires()
                        .IsGreaterThan(ClientId, 0, "ClientId", "O Id do cliente é obrigatório")
                        .HasMinLen(ClientFirstName, 3, "ClientFirstName", "O nome deve conter pelo menos 3 caracteres.")
                        .HasMinLen(ClientLastName, 3, "ClientLastName", "O sobrenome deve conter pelo menos 3 caracteres.")
                        .IsEmailOrEmpty(ClientEmail, "ClientEmail", "O e-mail é obrigatório.")
                        .IsNotNullOrWhiteSpace(ClientCompany, "ClientCompany", "O nome da empresa é obrigatório.")
                        .IsNotNullOrWhiteSpace(ClientToken, "ClienteToken", "O token do cliente é obrigatório.")
                        .IsNotNullOrWhiteSpace(ClientCallNumber, "ClientCallNumber", "O número de telefone é requirido.")
                        .HasMinLen(ClientFirstName, 3, "ClientFirstName", "O nome deve conter pelo menos 3 caracteres.")
                        .HasMinLen(Title, 3, "Title", "O títiulo deve conter pelo menos 3 caracteres.")
                        .HasMinLen(Description, 10, "Description", "A descrição deve conter pelo menos 10 caracteres.")
                        .IsNotNull(Status, "Status", "O status do ticket é obrigatório")
                        .IsNotNull(Priority, "Priority", "A prioridade do ticket é obrigatório")
                       );
        }
    }
}
