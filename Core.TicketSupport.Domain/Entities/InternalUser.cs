using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Domain.ValueObjects;
using Flunt.Validations;

namespace Core.TicketSupport.Domain.Entities
{
    public class InternalUser : User
    {
        public InternalUser(Name name, Email email, EAccessLevelType accessLevel) 
            : base(name, email)
        {
            AccessLevel = accessLevel;

            AddNotifications(new Contract()
                    .Requires()
                    .IsNull(AccessLevel, "InternalUser.Accesslevel", "O nível de acesso é obrigatório"));
        }

        public EAccessLevelType AccessLevel { get; private set; }
    }
}
