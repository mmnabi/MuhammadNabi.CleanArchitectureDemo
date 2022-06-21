using MediatR;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery : IRequest<EventExportFileVm>
    {
    }
}
