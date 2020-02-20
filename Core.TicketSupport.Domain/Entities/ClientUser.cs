using Core.TicketSupport.Domain.ValueObjects;
using Flunt.Validations;

namespace Core.TicketSupport.Domain.Entities
{
    public class ClientUser : User
    {
        public ClientUser(Name name, Email email, int clientId, string clientToken, string company, string callNumber) 
            : base(name, email)
        {
            ClientToken = clientToken;
            ClientId = clientId;
            Company = company;
            CallNumber = callNumber;

            AddNotifications(name, email);

            AddNotifications(new Contract()
                            .Requires()
                            .IsGreaterThan(ClientId, 0, "ClientUser.ClientId", "O Id do Cliente é Obrigatório")
                            .IsNotNullOrWhiteSpace(ClientToken, "ClientUser.ClientToken", "o token do cliente é obrigatório")
                            .IsNotNullOrWhiteSpace(Company, "ClientUser.Company", "O nome da empresa é obrigatório")
                            .IsNotNullOrWhiteSpace(CallNumber, "ClientUser.CallNumber", "O telefone é obrigatório"));
        }

        public int ClientId { get; private set; }

        public string ClientToken { get; private set; }

        public string Company { get; private set; }

        public string CallNumber { get; private set; }
    }
}
