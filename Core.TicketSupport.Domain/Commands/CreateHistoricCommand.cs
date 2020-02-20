using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Core.TicketSupport.Domain.Commands
{
    public class CreateHistoricCommand : Notifiable, ICommand
    {
        public string TicketId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public EHistoricInteractionType Interaction { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                        .Requires()
                        .IsNotNullOrWhiteSpace(TicketId, "TicketId", "O id do ticket é obrigatório.")
                        .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres.")
                        .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres.")
                        .IsEmailOrEmpty(Email, "Email", "O e-mail é obrigatório.")
                        .HasMinLen(Description, 3, "Description", "A descrição deve conter pelo menos 3 caracteres.")
                        .IsNotNull(Interaction, "Interaction", "O tipo da interação é obrigatório")
                        );
        }
    }
}
