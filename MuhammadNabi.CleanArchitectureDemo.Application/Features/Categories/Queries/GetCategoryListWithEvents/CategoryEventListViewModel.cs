using System;
using System.Collections.Generic;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryListWithEvents
{
    public class CategoryEventListViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}
