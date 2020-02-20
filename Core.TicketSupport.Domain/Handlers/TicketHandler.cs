using Core.TicketSupport.Domain.Commands;
using Core.TicketSupport.Domain.Entities;
using Core.TicketSupport.Domain.Repositories;
using Core.TicketSupport.Domain.ValueObjects;
using Core.TicketSupport.Shared.Commands;
using Core.TicketSupport.Shared.Handlers;
using Flunt.Notifications;

namespace Core.TicketSupport.Domain.Handlers
{
    public class TicketHandler :
        Notifiable,
        IHandler<CreateTicketCommand>
    {

        private readonly ITicketRepository _ticketRepsitory;

        public TicketHandler(ITicketRepository ticketRepsitory)
        {
            _ticketRepsitory = ticketRepsitory;
        }

        public ICommandResult Handle(CreateTicketCommand Commad)
        {
            // fail fast validations
            Commad.Validate();  
            if (Commad.Invalid)
            {
                AddNotifications(Commad);
                return new CommadResult(false, "Não foi possível realizar o seu cadastro");
            }

            // valida o status
            if(Commad.Status != Enums.ETicketStatusType.Aberta)
                AddNotification("Status", "O status inicial de um ticket não pode ser diferente de aberta");


            // Gerar so VO's
            var nameClientUser = new Name(Commad.ClientFirstName, Commad.ClientLastName);
            var emailClientUser = new Email(Commad.ClientEmail);
            var clientUser = new ClientUser(nameClientUser, 
                emailClientUser, 
                Commad.ClientToken, 
                Commad.ClientCompany, 
                Commad.ClientCallNumber);

            //gerar a entidade
            var ticket = new Ticket(Commad.Title, Commad.Description, Commad.Status, Commad.Priority, clientUser);

            // agrupar as validações
            AddNotifications(nameClientUser, emailClientUser, clientUser, ticket);

            // valida
            if(Invalid)
                return new CommadResult(false, "Erro ao salva o ticket");
    
            // salva o ticket
            _ticketRepsitory.CreateTicket(ticket);
            return new CommadResult(true, "Ticket salvo com sucesso");
        }


    }
}
