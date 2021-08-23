using GloboTicket.Ticketmanagement.Application.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly GloboTicketDBContext _context;

        public BaseRepository(GloboTicketDBContext GloboTicketDBContext)
        {
            _context = GloboTicketDBContext;
        }
        public async Task<T> AddAsync(T Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();

            return Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyCollection<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();                
        }

        public async Task UpdateAcync(T entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
