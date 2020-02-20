using Core.TicketSupport.Domain.Commands;
using Core.TicketSupport.Domain.Enums;
using Xunit;

namespace Core.TicketSupport.Tests.Commands
{
    public class CreateTicketCommadTests
    {
        [Theory]
        [InlineData("fe", "ma", "felipe_gmail.com", "jshdos", "m","fd", "", "tn", ETicketStatusType.Aberta, EPriorityType.Baixa)]
        [InlineData("", "", "felipe_@@gmail.com", "jshdos", "m", "fs", "d", "Grupo Mult", ETicketStatusType.Aberta, EPriorityType.Baixa)]
        public void DeveRetornarErroSeCommandInvalido(
            string nome, 
            string sobrenome,
            string email,
            string token,
            string empresa,
            string telefone,
            string title,
            string description,
            ETicketStatusType status,
            EPriorityType prioridade
            )
        {
            CreateTicketCommand command = new CreateTicketCommand
            {
                
                ClientFirstName = nome,
                ClientLastName = sobrenome,
                ClientEmail = email,
                ClientToken = token,
                ClientCompany = empresa,
                ClientCallNumber = telefone,
                Title = title,
                Description = description,
                Status = status,
                Priority = prioridade
            };
            command.Validate();
            Assert.True(command.Invalid);
        }


        [Theory]
        [InlineData(
            1,
            "Felipe", 
            "Machado", 
            "felipemmachado28@gmail.com", "k238388h29", 
            "Grupo Mult", "31 9 85988217",
            "Ticket legal aberto",
            "Houve um erro muito foda, mas seus meninos são bons.",
            ETicketStatusType.Aberta, EPriorityType.Baixa)]
        public void DeveRetornarSucessoSeCommandValido(
            int clientId,
            string nome,
            string sobrenome,
            string email,
            string token,
            string empresa,
            string telefone,
            string title,
            string description,
            ETicketStatusType status,
            EPriorityType prioridade
            )
        {
            CreateTicketCommand command = new CreateTicketCommand
            {
                ClientId = clientId,
                ClientFirstName = nome,
                ClientLastName = sobrenome,
                ClientEmail = email,
                ClientToken = token,
                ClientCompany = empresa,
                ClientCallNumber = telefone,
                Title = title,
                Description = description,
                Status = status,
                Priority = prioridade
            };
            command.Validate();
            Assert.True(command.Valid);
        }

    }
}
