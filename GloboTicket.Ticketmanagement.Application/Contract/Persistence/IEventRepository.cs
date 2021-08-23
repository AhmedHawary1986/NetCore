using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
       public Task<bool> IsEventNameAndDateUnique(string Name, DateTime date);
    }
}
