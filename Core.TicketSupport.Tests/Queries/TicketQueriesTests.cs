using Core.TicketSupport.Domain.Entities;
using Core.TicketSupport.Domain.Queries;
using Core.TicketSupport.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Core.TicketSupport.Tests.Queries
{
    public class TicketQueriesTests
    {
        private IList<Ticket> _tickets;

        public TicketQueriesTests()
        {
            _tickets = new List<Ticket>();

            for (var i = 0; i < 10; i++)
            {
                var clientUser = new ClientUser(
                    new Name($"Felipe {i}", $"machado {i}"),
                    new Email($"felipemmachado2{i}@gmail.com"),
                    i,
                    $"sjashdfaisdfha{i}",
                    $"MULT {i}",
                    $"3198598821{i}"
                 );

                var ticket = new Ticket(
                    $"0000{i}-{i}",
                    $"Ticket {i}",
                    $"Descrição do ticket {i}",
                    Domain.Enums.ETicketStatusType.Aberta,
                    Domain.Enums.EPriorityType.Baixa,
                    clientUser);

                _tickets.Add(ticket);
            }
        }

        [Fact]
        public void DeveRetornarNullQuandoNaoExistirTicket()
        {
            var exp = TicketQueries.GetTicketByCode("0000-0");
            var ticket = _tickets.AsQueryable().Where(exp).FirstOrDefault();

            Assert.Null(ticket);
        }

        [Theory]
        [InlineData("00001-1")]
        [InlineData("00002-2")]
        [InlineData("00003-3")]
        public void DeveRetornarTicketQuandoExistir(string codigo)
        {
            var exp = TicketQueries.GetTicketByCode(codigo);
            var ticket = _tickets.AsQueryable().Where(exp).FirstOrDefault();

            Assert.NotNull(ticket);
        }

    }
}
