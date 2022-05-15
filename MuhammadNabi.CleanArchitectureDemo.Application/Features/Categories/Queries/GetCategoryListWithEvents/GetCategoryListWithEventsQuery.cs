using MediatR;
using System.Collections.Generic;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class GetCategoryListWithEventsQuery : IRequest<List<CategoryEventListViewModel>>
    {
        public bool IncludeHistory { get; set; }
    }
}
