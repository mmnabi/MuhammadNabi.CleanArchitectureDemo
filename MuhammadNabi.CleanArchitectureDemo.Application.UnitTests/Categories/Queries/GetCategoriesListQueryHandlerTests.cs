using AutoMapper;
using Moq;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Persistence;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryList;
using MuhammadNabi.CleanArchitectureDemo.Application.Profiles;
using MuhammadNabi.CleanArchitectureDemo.Application.UnitTests.Mocks;
using MuhammadNabi.CleanArchitectureDemo.Domain.Entities;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MuhammadNabi.CleanArchitectureDemo.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListViewModel>>();

            result.Count.ShouldBe(4);
        }
    }
}
