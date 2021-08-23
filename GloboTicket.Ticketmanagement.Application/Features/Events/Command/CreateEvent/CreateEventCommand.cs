using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Artist { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public string ImageURL { get; set; }


        public override string ToString()
        {
            return $"Event Name : {Name} , Price : {Price} , By : {Artist} , On {Date} , about : {Description} ";
        }
    }
}
