using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Execeptions;
using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events.Command.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Event> _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Event> EategoryRepository, IMapper Mapper)
        {
            _eventRepository = EategoryRepository;
            _mapper = Mapper;
        }
        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventInDB = await _eventRepository.GetByIdAsync(request.EventId);

            if(eventInDB == null)
            {
                throw new NotFoundException(nameof(Event), request.EventId);
            }

            _mapper.Map(request, eventInDB, typeof(UpdateEventCommand), typeof(GloboTicket.TicketManagement.Domain.Entities.Event));

            await _eventRepository.UpdateAcync(eventInDB);

            return Unit.Value;
        }
    }
}
