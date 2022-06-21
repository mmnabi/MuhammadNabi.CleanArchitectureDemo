using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Commands.CreateCategory;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryList;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryListWithEvents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuhammadNabi.CleanArchitectureDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListViewModel>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }

        [HttpGet("allwithevents", Name = "GetCategoriesWithEvents")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryEventListViewModel>>> GetCategoriesWithEvents(bool includeHistory)
        {
            var dtos = await _mediator.Send(new GetCategoryListWithEventsQuery() { IncludeHistory = includeHistory });
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }
    }
}
