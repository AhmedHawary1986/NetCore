using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events.Queries.GetEventsExport
{
    public class EventExportFileVM
    {
        public string ExportFileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }
    }
}
