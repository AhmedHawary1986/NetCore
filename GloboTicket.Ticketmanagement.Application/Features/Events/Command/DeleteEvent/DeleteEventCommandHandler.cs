using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events.Command.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Event> _eventRepository;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Event> EategoryRepository, IMapper Mapper)
        {
            _eventRepository = EategoryRepository;
            _mapper = Mapper;
        }
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToBeDeleted = await _eventRepository.GetByIdAsync(request.EventId);

                await _eventRepository.DeleteAsync(eventToBeDeleted);

            return Unit.Value;
        }
    }
}
