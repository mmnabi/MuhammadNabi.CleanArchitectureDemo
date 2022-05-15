using MuhammadNabi.CleanArchitectureDemo.Application.Responses;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {

        }

        public CreateCategoryDto Category { get; set; }
    }
}
