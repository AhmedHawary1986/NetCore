using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        public Task<List<Order>> GetPagedOrderForMonth(DateTime date, int page, int size);

        public Task<int> GetTotalOrderForMonth(DateTime date);
    }
}
