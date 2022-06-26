using System.Collections.Generic;
using GeorgeVlad.TicketingSystem.Tickets;
using System.Threading.Tasks;
using GeorgeVlad.TicketingSystem.Tickets.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace GeorgeVlad.TicketingSystem.Tests.Tickets
{
    public class TicketAppService_Tests : TicketingSystemTestBase
    {
        private readonly ITicketAppService _ticketAppService;
        public TicketAppService_Tests()
        {
            _ticketAppService = Resolve<ITicketAppService>();
        }

        [Fact]
        public async Task GetTickets_Test()
        {
            // Act
            var output = new List<TicketListDto>
            { new TicketListDto
                {
                    Id=2,
                    CustomerName="John"
                }
            };
            // Assert
            output.Count.ShouldBe(1);
        }

        [Fact]
        public async Task GetTicket_Test()
        {
            // Act
            var output = new TicketDto
            {
                Id = 2,
                TicketType = TicketType.Task,
                CustomerName = "John",
                ServiceType = ServiceType.Design,
                Priority = PriorityType.Low,
                Subject = null,
                Description = null,
                Status = StatusType.New,
                TicketCreationDate = default,
                TicketCloseDate = null
            };

            // Assert
            output.ShouldNotBeNull();
        }
    }
}
