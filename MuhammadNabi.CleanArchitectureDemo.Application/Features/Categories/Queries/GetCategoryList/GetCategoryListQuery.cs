using MediatR;
using System.Collections.Generic;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListViewModel>>
    {
    }
}
