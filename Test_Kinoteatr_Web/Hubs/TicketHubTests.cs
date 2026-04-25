using Kinoteatr_Web_2027.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kinoteatr_Web_2027.Hubs;
using Moq;

namespace Test_Kinoteatr_Web.Hubs
{
    public class TicketHubTests
    {
        [Fact]
        public async Task SendTicketUpdate_ShouldSendMessageToAllClients()
        {
            // Arrange
            var hub = new TicketHub();

            var clientsMock = new Mock<IHubCallerClients>();
            var clientProxyMock = new Mock<IClientProxy>();

            clientsMock.Setup(c => c.All).Returns(clientProxyMock.Object);

            hub.Clients = clientsMock.Object;

            var ticket = new Ticket
            {
                Title = "Test Book",
                Date = DateTime.Now.AddDays(30),
                Summa = 1500
            };

            // Act
            await hub.SendTicketUpdate(ticket);

            // Assert
            clientProxyMock.Verify(
                c => c.SendCoreAsync(
                    "TicketUpdated",
                    It.Is<object[]>(o => o.Length == 1 && o[0] == ticket),
                    default
                ),
                  Times.Once
            );
        }
    }
}
