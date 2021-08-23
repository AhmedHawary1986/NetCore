using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events
{
    public class EventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsVM>
    {
     private readonly IMapper _mapper;
     private readonly IAsyncRepository<Event> _eventRepository;
     private readonly IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category> _categoryRepository;
     
        public EventDetailsQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category> categoryRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<EventDetailsVM> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            var EventDetailDto = _mapper.Map<EventDetailsVM>(@event);

            var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

            var CategoryDto = _mapper.Map<CategoryDTO>(category);
            EventDetailDto.Category = CategoryDto;

            return EventDetailDto;
        }
    }
}
