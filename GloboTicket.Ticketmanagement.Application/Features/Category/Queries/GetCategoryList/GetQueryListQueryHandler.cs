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

namespace GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryList
{
    public class GetQueryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListVM>>
    {
        private readonly IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetQueryListQueryHandler(IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category> CategoryRepository, IMapper Mapper)
        {
            _categoryRepository = CategoryRepository;
            _mapper = Mapper;
        }

        public async Task<List<CategoryListVM>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var List = await _categoryRepository.ListAllAsync();

            return _mapper.Map<List<CategoryListVM>>(List);
        }
    }
}
