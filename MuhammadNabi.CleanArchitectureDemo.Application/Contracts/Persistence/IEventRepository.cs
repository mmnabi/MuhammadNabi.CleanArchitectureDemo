using MuhammadNabi.CleanArchitectureDemo.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
