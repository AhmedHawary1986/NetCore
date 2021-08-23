using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.Ticketmanagement.Application.Execeptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GloboTicket.Ticketmanagement.Application.Contract.Infrastructure;
using GloboTicket.Ticketmanagement.Application.Model;
using Microsoft.Extensions.Logging;

namespace GloboTicket.Ticketmanagement.Application.Features.Events.Command.CreateEvent
{
    class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(IEventRepository EventRepository, IMapper Mapper, IEmailService EmailService, ILogger<CreateEventCommandHandler> logger)
        {
            _eventRepository = EventRepository;
            _mapper = Mapper;
            _emailService = EmailService;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validatorResult = await validator.ValidateAsync(request);


            if(validatorResult.Errors.Count>0)
            {
                throw new ValidationException(validatorResult);
            }

            var @event = _mapper.Map<GloboTicket.TicketManagement.Domain.Entities.Event>(request);

           var insertedEvent = await _eventRepository.AddAsync(@event);

            try
            {
                var email = new Email() { To = "Ahmad.hwry@gmail.com", Subject = "A new event created" , Body=$"A new event created : {request}" };

               await  _emailService.SendEmail(email);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Mailing at {@event.EventId} failed due to error at email service : {ex.Message}");
            }

            return insertedEvent.EventId;
        }
    }
}
