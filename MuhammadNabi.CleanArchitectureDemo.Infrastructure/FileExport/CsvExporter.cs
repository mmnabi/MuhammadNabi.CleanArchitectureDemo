using CsvHelper;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Infrastructure;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MuhammadNabi.CleanArchitectureDemo.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
