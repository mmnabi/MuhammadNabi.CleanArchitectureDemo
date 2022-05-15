using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery : IRequest<EventDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
