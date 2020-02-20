using Core.TicketSupport.Domain.Entities;
using Core.TicketSupport.Domain.Enums;
using Core.TicketSupport.Domain.ValueObjects;
using System;
using Xunit;

namespace Core.TicketSupport.Tests.Entities
{
    public class TicketTests
    {
        private readonly Name _nameClientUser;
        private readonly Email _emailClientUser;
        private readonly ClientUser _clientUser;

        private readonly Name _nameInternalUser;
        private readonly Email _emailInternalUser;
        private readonly InternalUser _internalUser;

        private readonly Ticket _ticket;
        private readonly Historic _historic;

        public TicketTests()
        {
            _nameClientUser = new Name("Felipe", "Machado");
            _emailClientUser = new Email("felipemmachado28@gmail.com");
            _clientUser = new ClientUser(_nameClientUser, _emailClientUser, 2, "kkhsaoskeeh", "Grupo Mult", "31985988217");
            _ticket = new Ticket("00001-0", "title","Descrição do ticket", ETicketStatusType.Aberta, EPriorityType.Alta, _clientUser);

            _nameInternalUser = new Name("Felipe", "Machado");
            _emailInternalUser = new Email("felipe.machado@grupomult.com.br");

            _internalUser = new InternalUser(_nameInternalUser, _emailInternalUser, EAccessLevelType.Analista);
            _historic = new Historic(_nameInternalUser, _emailInternalUser, "O erro acontece quando eu clino no vai.", EHistoricInteractionType.Interação);
        }

        [Theory]
        [InlineData(null)]
        public void DeveRetornarErroSeAdicionarUmHistoricoNull(Historic historic)
        {
            _ticket.AddHistoric(historic);
            Assert.True(_ticket.Invalid);
        }

        [Fact]
        public void DeveRetonarSucessoAoSeAdicionarUmHistorico()
        {
            _ticket.AddHistoric(_historic);
            Assert.True(_ticket.Valid);
            Assert.Equal(1, _ticket.Historics.Count);
        }

        [Theory]
        [InlineData(2010, 10, 10, 20, 10, 10)]
        [InlineData(2020, 02, 19, 15, 55, 00)]
        public void DeveRetonarErroSeDataPrevisaoForMenorQueAgora(int year, int month, int day, int hour, int minute, int second)
        {
            DateTime date = new DateTime(year, month, day, hour, minute, second);
            _ticket.SetForecastDate(date);
            Assert.True(_ticket.ForecastDate <= DateTime.UtcNow && _ticket.Invalid);
        }

        [Fact]
        public void DeveRetonarSucessoAoAddDataPrevisao()
        {
            DateTime date = DateTime.UtcNow.AddDays(1);
            _ticket.SetForecastDate(date);
            Assert.True(_ticket.ForecastDate >= DateTime.UtcNow && _ticket.Valid);
        }

        [Fact]
        public void DeveRetonarAoSetarUmResponsavelNull()
        {
            _ticket.ChangeResponsable(null);
            Assert.True(_ticket.Invalid);
        }

        [Fact]
        public void DeveRetonarSucessoAoSetarUmResponsavel()
        {
            _ticket.ChangeResponsable(_internalUser);
            Assert.True(_ticket.Valid);
        }

        [Fact]
        public void DeveRetonarSucessoAoSetarStatus()
        {
            _ticket.ChangeStatus(ETicketStatusType.Aberta);
            Assert.True(_ticket.Valid);
        }

        [Theory]
        [InlineData(2010, 10, 10, 20, 10, 10)]
        [InlineData(2020, 02, 19, 15, 55, 00)]
        public void DeveRetonarErroSeDataConclusaoForMenorQueAgora(int year, int month, int day, int hour, int minute, int second)
        {
            DateTime date = new DateTime(year, month, day, hour, minute, second);
            _ticket.Conclude(date);
            Assert.True(_ticket.ConclusionDate <= DateTime.UtcNow && _ticket.Invalid);
        }

        [Fact]
        public void DeveRetornarSuceessoAoConcluirTicket()
        {
            DateTime date = DateTime.UtcNow.AddSeconds(2);
            _ticket.Conclude(date);
            Assert.True(_ticket.Valid);
        }
    }
}
