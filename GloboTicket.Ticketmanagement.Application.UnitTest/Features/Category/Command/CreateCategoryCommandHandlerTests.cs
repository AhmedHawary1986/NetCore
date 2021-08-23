using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Features.Category.Command.CreateCategory;
using GloboTicket.Ticketmanagement.Application.Persistence;
using GloboTicket.Ticketmanagement.Application.Profiles;
using GloboTicket.Ticketmanagement.Application.UnitTest.Mocks;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GloboTicket.Ticketmanagement.Application.UnitTest.Features.Category.Command
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IAsyncRepository<GloboTicket.TicketManagement.Domain.Entities.Category>> mockRepository;

        public CreateCategoryCommandHandlerTests()
        {
            var mappingConfiguration = new MapperConfiguration(c => c.AddProfile<MappingProfiles>());
            mapper = mappingConfiguration.CreateMapper();

            mockRepository = RepositoryMocks.GetCategoryRepository();
        }

        [Fact]
        public async Task AddCategory()
        {
            var handler = new CreateCategoryCommandHandler(mockRepository.Object, mapper);
            var result = await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var categoryList = await mockRepository.Object.ListAllAsync();

            categoryList.Count.ShouldBe(5);
        }

        [Fact]
        public async Task AddFailedCategory()
        {
            var handler = new CreateCategoryCommandHandler(mockRepository.Object, mapper);
            var result = await handler.Handle(new CreateCategoryCommand() { Name = "" }, CancellationToken.None);

            result.Success.ShouldBeFalse();
        }

    }
}
