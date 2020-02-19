using Core.TicketSupport.Shared.ValueObjects;
using Flunt.Validations;

namespace Core.TicketSupport.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                                .Requires()
                                .IsNotNullOrWhiteSpace(address, "email", "O email é obrigatório") 
                                .IsEmailOrEmpty(address, "email", "E-mail inválido."));
        }
        public string Address { get; private set; }
    }
}
