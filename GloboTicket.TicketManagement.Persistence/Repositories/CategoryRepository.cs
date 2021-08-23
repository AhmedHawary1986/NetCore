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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GloboTicketDBContext context): base(context)
        {

        }

        public async Task<List<Category>> GetCategoryListWithEvents(bool IncludeHistory)
        {
            var allCategories = await _context.Categories.Include(x => x.Events).ToListAsync();
            if(!IncludeHistory)
            {
                allCategories.ForEach(x => x.Events.ToList().RemoveAll(y => y.Date < DateTime.Today));
            }

            return allCategories;
        }
    }
}
