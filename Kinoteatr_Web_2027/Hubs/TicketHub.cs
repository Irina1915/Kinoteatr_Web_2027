using Kinoteatr_Web_2027.Models;
using Microsoft.AspNetCore.SignalR;

namespace Kinoteatr_Web_2027.Hubs
{
    public class TicketHub: Hub
    {
        // Отправка обновления фильма всем клиентам
        public async Task SendTicketUpdate(Ticket ticket)
        {
            await Clients.All.SendAsync("TicketUpdated", ticket);
        }
    }
}
