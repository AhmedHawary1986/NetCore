using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GloboTicketDBContext context):base(context)
        {

        }

        public Task<bool> IsEventNameAndDateUnique(string Name, DateTime date)
        {
            var matches = _context.Events.Any(e => e.Name == Name && e.Date == date);

            return Task.FromResult(matches);
        }
    }
}
