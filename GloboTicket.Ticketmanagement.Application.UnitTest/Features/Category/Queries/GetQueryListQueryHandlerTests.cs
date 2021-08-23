using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryList;
using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.Ticketmanagement.Application.Profiles;
using GloboTicket.Ticketmanagement.Application.UnitTest.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Xunit;
using System.Threading;
using Shouldly;

namespace GloboTicket.Ticketmanagement.Application.UnitTest.Features.Category.Queries
{
    public class GetQueryListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category>> mockRepository;
        public GetQueryListQueryHandlerTests()
        {
            mockRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(c => c.AddProfile<MappingProfiles>());
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task CheckCategoryReturnType()
        {
            var handler = new GetQueryListQueryHandler(mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVM>>();
            
        }

        [Fact]

        public async Task CheckCategoryReturnCount()
        {
            var handler = new GetQueryListQueryHandler(mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            result.Count.ShouldBe(4);

        }

    }
}
