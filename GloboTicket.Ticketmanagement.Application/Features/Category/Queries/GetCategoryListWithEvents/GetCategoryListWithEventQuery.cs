using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventQuery : IRequest<List<CategoryEventListVM>>
    {
        public bool IncludeHistory { get; set; }
    }
}
