using GloboTicket.Ticketmanagement.Application.Contract.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTest
{
    public class GloboTicketDBContextTest
    {
        private readonly Mock<ILoggedinUserService> loggedInUserService;
        private readonly GloboTicketDBContext context;
        private readonly string userId;

        public GloboTicketDBContextTest()
        {
            loggedInUserService = new Mock<ILoggedinUserService>();
            userId = new Guid().ToString();
            loggedInUserService.Setup(r => r.UserId).Returns(userId);

            var options = new DbContextOptionsBuilder<GloboTicketDBContext>().UseInMemoryDatabase(new Guid().ToString()).Options;
            context = new GloboTicketDBContext(options, loggedInUserService.Object);
        }

        [Fact]
        public async Task TestCreatedBy()
        {
            var eventInMemory = new Event() { EventId=new Guid(),Name = "TestEvent" };

            context.Events.Add(eventInMemory);

            await context.SaveChangesAsync();

            eventInMemory.CreatedBy.ShouldBe(userId);

        }
    }
}
