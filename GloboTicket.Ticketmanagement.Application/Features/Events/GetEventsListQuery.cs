using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events
{
    public class GetEventsListQuery : IRequest<List<EventListVM>>
    {
    }
}
