using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Category.Command.CreateCategory
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }
    }
}
