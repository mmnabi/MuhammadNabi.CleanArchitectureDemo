﻿using MediatR;
using System;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}
