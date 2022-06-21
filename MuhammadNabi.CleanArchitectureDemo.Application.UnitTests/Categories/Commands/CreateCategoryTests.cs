using AutoMapper;
using Moq;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Persistence;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Commands.CreateCategory;
using MuhammadNabi.CleanArchitectureDemo.Application.Profiles;
using MuhammadNabi.CleanArchitectureDemo.Application.UnitTests.Mocks;
using MuhammadNabi.CleanArchitectureDemo.Domain.Entities;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MuhammadNabi.CleanArchitectureDemo.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(5);
        }
    }
}
