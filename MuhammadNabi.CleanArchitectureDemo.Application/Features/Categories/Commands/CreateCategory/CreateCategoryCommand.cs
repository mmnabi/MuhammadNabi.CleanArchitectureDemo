using MediatR;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
