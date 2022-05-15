using MediatR;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Persistence;
using MuhammadNabi.CleanArchitectureDemo.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

            //if (eventToDelete == null)
            //{
            //    throw new NotFoundException(nameof(Event), request.EventId);
            //}

            await _eventRepository.DeleteAsync(eventToDelete);

            return Unit.Value;

        }
    }
}
