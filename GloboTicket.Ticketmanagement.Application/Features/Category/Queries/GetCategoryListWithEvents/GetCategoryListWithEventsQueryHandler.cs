using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventsQueryHandler : IRequestHandler<GetCategoryListWithEventQuery, List<CategoryEventListVM>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListWithEventsQueryHandler(ICategoryRepository CategoryRepository, IMapper Mapper)
        {
            _categoryRepository = CategoryRepository;
            _mapper = Mapper;
        }
        public async Task<List<CategoryEventListVM>> Handle(GetCategoryListWithEventQuery request, CancellationToken cancellationToken)
        {
            var List = await _categoryRepository.GetCategoryListWithEvents(request.IncludeHistory);

            return _mapper.Map<List<CategoryEventListVM>>(List);
        }
    }
}
