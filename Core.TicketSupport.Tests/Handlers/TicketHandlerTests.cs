using Core.TicketSupport.Domain.Commands;
using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Domain.Handlers;
using Core.TicketSupport.Tests.Mocks;
using Xunit;

namespace Core.TicketSupport.Tests.Handlers
{
    public class TicketHandlerTests
    {
        [Fact]
        public void DeveRetonarErroSeStatusNaoForAberto()
        {
            var handler = new TicketHandler(new FakeTicketRepository());

            CreateTicketCommand command = new CreateTicketCommand
            {
                ClientFirstName = "Felipe",
                ClientLastName = "Machado",
                ClientEmail = "felipe@gmail.com",
                ClientToken = "4383733gfdd",
                ClientCompany = "Grupo Mult",
                ClientCallNumber = "31 9 85988217",
                Title = "titulo",
                Description = "Descrição do Ticket",
                Status = ETicketStatusType.Cancelada,
                Priority = EPriorityType.Baixa,
            };

            handler.Handle(command);
            Assert.True(handler.Invalid);
        }

        [Fact]
        public void DeveRetonarSucessoSeStatusForAberto()
        {
            var handler = new TicketHandler(new FakeTicketRepository());

            CreateTicketCommand command = new CreateTicketCommand
            {
                ClientFirstName = "Felipe",
                ClientLastName = "Machado",
                ClientEmail = "felipe@gmail.com",
                ClientToken = "4383733gfdd",
                ClientCompany = "Grupo Mult",
                ClientCallNumber = "31 9 85988217",
                Title = "titulo",
                ClientId = 1,
                Description = "Descrição do ticket",
                Status = ETicketStatusType.Aberta,
                Priority = EPriorityType.Baixa,
            };

            handler.Handle(command);
            Assert.True(handler.Valid);
        }
    }
}
