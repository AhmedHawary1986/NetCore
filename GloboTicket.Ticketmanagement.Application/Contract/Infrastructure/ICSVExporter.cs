using GloboTicket.Ticketmanagement.Application.Features.Events.Queries.GetEventsExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Contract.Infrastructure
{
    public interface ICSVExporter
    {
        public byte[] ExportEventsToCSV(List<EventExportDto> events);
    }
}
