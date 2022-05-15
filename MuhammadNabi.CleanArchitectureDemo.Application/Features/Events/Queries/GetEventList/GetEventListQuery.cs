using MediatR;
using System.Collections.Generic;
using System.Text;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventListViewModel>>
    {
    }
}
