using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Contract.Infrastructure;
using GloboTicket.Ticketmanagement.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, EventExportFileVM>
    {
        public readonly IEventRepository _eventRepository;
        public readonly IMapper _mapper;
        public readonly ICSVExporter _cSVExporter;
        public GetEventsExportQueryHandler(IEventRepository eventRepository, IMapper mapper, ICSVExporter cSVExporter)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _cSVExporter = cSVExporter;
        }
        public async Task<EventExportFileVM> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var events = _mapper.Map<List<EventExportDto>>((await _eventRepository.ListAllAsync()).OrderBy(x => x.Date));

            var FileData = _cSVExporter.ExportEventsToCSV(events);

            EventExportFileVM exportVM = new EventExportFileVM() { Data = FileData, ContentType = "text/csv", ExportFileName = $"{new Guid()}.csv" };

            return exportVM;
        }
    }
}
