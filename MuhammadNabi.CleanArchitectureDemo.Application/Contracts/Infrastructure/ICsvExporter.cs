using MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
