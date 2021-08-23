using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Category.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category> categoryRepository;

        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category> CategoryRepository,IMapper Mapper)
        {
            categoryRepository = CategoryRepository;
            mapper = Mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryCommandResponse();
            var validaton = new CreateCategoryCommandValidator();
            var validationResult = await validaton.ValidateAsync(request);
            if (validationResult.Errors.Count>0)
            {
                response.ValidationErrors = new List<string>();
                foreach (var validationError in validationResult.Errors)
                {
                    response.ValidationErrors.Add(validationError.ErrorMessage);
                }
                response.Success = false;
            }
            else
            {

                response.Success = true;

                var categoryEntity = await categoryRepository.AddAsync(new TicketManagement.Domain.Entities.Category() { Name = request.Name });

                response.CreateCategoryDto = mapper.Map<CreateCategoryDto>(categoryEntity);
            }

            return response;
        }
    }
}
