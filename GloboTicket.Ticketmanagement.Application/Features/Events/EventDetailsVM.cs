﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events
{
    public class EventDetailsVM
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Artist { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
