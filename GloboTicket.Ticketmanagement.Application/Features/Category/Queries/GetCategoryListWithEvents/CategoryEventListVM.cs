using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryListWithEvents
{
    public class CategoryEventListVM
    {
        public Guid CategoryId { get; set; }

        public String Name { get; set; }

        public ICollection<CategoryEventDTO> Events { get; set; }
    }
}
