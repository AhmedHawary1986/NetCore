using FluentValidation;
using GloboTicket.Ticketmanagement.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Events.Command.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandValidator(IEventRepository EventRepository)
        {
            _eventRepository = EventRepository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull().MaximumLength(50).WithMessage("{PropertyName} not exeec 50 charachterd");
            RuleFor(p => p.Date).NotEmpty().WithMessage("{PropertyName} is required").NotNull().GreaterThan(DateTime.Now);
            RuleFor(p => p.Price).NotEmpty().WithMessage("{PropertyName} is required").NotNull().GreaterThan(0);
            RuleFor(e => e).MustAsync(NameAndDateUnique).WithMessage("An event with same name and same date already exists ");

        }

        private async Task<bool> NameAndDateUnique(CreateEventCommand e, CancellationToken cancellationToken)
        {
            return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));
        }
    }
}
