using Core.TicketSupport.Shared.ValueObjects;
using Flunt.Validations;

namespace Core.TicketSupport.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                        .Requires()
                        .HasMaxLen(firstName, 3, "firstName", "Primeiro nome obrigatório")
                        .HasMaxLen(lastName, 3, "lastName", "sobrenome obrigatório"));
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
