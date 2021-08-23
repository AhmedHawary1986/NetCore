using CsvHelper;
using CsvHelper.Configuration;
using GloboTicket.Ticketmanagement.Application.Contract.Infrastructure;
using GloboTicket.Ticketmanagement.Application.Features.Events.Queries.GetEventsExport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Infrastructure.FileExporter
{
    public class CSVExporter : ICSVExporter
    {
        public byte[] ExportEventsToCSV(List<EventExportDto> events)
        {
            using var memorystream = new MemoryStream(); 
            {
                using (var streamWriter = new StreamWriter(memorystream))
                {
                    using(var csvWriter= new CsvWriter(streamWriter,new System.Globalization.CultureInfo("en-US")))
                    {
                        csvWriter.WriteRecords(events);
                    }
                }


                return memorystream.ToArray();
            }
        }
    }
}
