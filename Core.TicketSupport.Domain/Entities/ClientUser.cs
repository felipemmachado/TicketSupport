using Core.TicketSupport.Domain.ValueObjects;
using Flunt.Validations;

namespace Core.TicketSupport.Domain.Entities
{
    public class ClientUser : User
    {
        public ClientUser(Name name, Email email, string clienteToken, string company, string callNumber) 
            : base(name, email)
        {
            ClienteToken = clienteToken;
            Company = company;
            CallNumber = callNumber;

            AddNotifications(name, email);

            AddNotifications(new Contract()
                            .Requires()
                            .IsNotNullOrWhiteSpace(ClienteToken, "ClientUser.ClienteToken", "o token do cliente é obrigatório")
                            .IsNotNullOrWhiteSpace(Company, "ClientUser.Company", "O nome da empresa é obrigatório")
                            .IsNotNullOrWhiteSpace(CallNumber, "ClientUser.CallNumber", "O telefone é obrigatório"));
        }

        public string ClienteToken { get; private set; }

        public string Company { get; private set; }

        public string CallNumber { get; private set; }
    }
}
