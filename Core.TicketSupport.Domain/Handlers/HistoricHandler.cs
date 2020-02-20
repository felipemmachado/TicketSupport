using Core.TicketSupport.Domain.Commands;
using Core.TicketSupport.Domain.Repositories;
using Core.TicketSupport.Shared.Commands;
using Core.TicketSupport.Shared.Handlers;
using Flunt.Notifications;

namespace Core.TicketSupport.Domain.Handlers
{
    public class HistoricHandler : Notifiable, IHandler<CreateHistoricCommand>
    {
        private readonly ITicketRepository _ticketRepsitory;

        public HistoricHandler(ITicketRepository ticketRepsitory)
        {
            _ticketRepsitory = ticketRepsitory;
        }

        public ICommandResult Handle(CreateHistoricCommand Commad)
        {
            // fail fast validations
            Commad.Validate();
            if (Commad.Invalid)
            {
                AddNotifications(Commad);
                return new CommadResult(false, "Não foi possível cadastrar um histórico");
            }

            // TODO recuperar o ticket para poder adicionar o histórico


            // salvar o ticket

            return new CommadResult(true, "Histórico salvo com sucesso");
        }
    }
}
