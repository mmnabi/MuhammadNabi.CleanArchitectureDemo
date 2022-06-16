﻿using AutoMapper;
using MediatR;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Infrastructure;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Persistence;
using MuhammadNabi.CleanArchitectureDemo.Application.Models.Mail;
using MuhammadNabi.CleanArchitectureDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        //private readonly ILogger<CreateEventCommandHandler> _logger;


        public CreateEventCommandHandler(
            IMapper mapper,
            IEventRepository eventRepository,
            IEmailService emailService)
        //ILogger<CreateEventCommandHandler> logger)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
            //_logger = logger;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepository.AddAsync(@event);

            //Sending email notification to admin address
            var email = new Email() { To = "mmnabi.cse@gmail.com", Body = $"A new event was created: {request}", Subject = "A new event was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                //_logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
            }

            return @event.EventId;
        }
    }
}
