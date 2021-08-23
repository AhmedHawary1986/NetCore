using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>,IOrderRepository
    {
     
        public OrderRepository(GloboTicketDBContext context) : base(context)
        {
           
        }

        public async Task<List<Order>> GetPagedOrderForMonth(DateTime date, int page, int size)
        {
            return await _context.Orders.Where(x => x.OrderPlaced.Year == date.Year && x.OrderPlaced.Month == date.Month).Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalOrderForMonth(DateTime date)
        {
            return await _context.Orders.CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
        }
    }
}
