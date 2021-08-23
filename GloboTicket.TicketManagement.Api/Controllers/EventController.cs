using GloboTicket.Ticketmanagement.Application.Features.Events;
using GloboTicket.Ticketmanagement.Application.Features.Events.Command.CreateEvent;
using GloboTicket.Ticketmanagement.Application.Features.Events.Command.DeleteEvent;
using GloboTicket.Ticketmanagement.Application.Features.Events.Command.UpdateEvent;
using GloboTicket.Ticketmanagement.Application.Features.Events.Queries.GetEventsExport;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("All", Name ="GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<EventListVM>>> GetEvents()
        {
            var Events = await _mediator.Send(new GetEventsListQuery());
            return Ok(Events);
        }

        [HttpGet("{id}",Name ="GetEventDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<EventDetailsVM>> GetEventDetails(Guid id)
        {
            var eventWithDetail = await _mediator.Send(new GetEventDetailsQuery() { Id=id});
            return Ok(eventWithDetail);
        }

        [HttpPost("AddEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventCommand request)
        {
            Guid eventId = await _mediator.Send(request);
            return Ok(eventId);
        }

        [HttpPut("UpdateEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromBody] UpdateEventCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("DeleteEvent")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromBody]  DeleteEventCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpGet("Export", Name ="ExportEvents")]
        public async Task<FileResult> ExportEvents()
        {
            EventExportFileVM file = await _mediator.Send(new GetEventsExportQuery());
            return File(file.Data, file.ContentType, file.ExportFileName);
        }


    }
}
