using MuhammadNabi.CleanArchitectureDemo.Application.Models.Mail;
using System.Threading.Tasks;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
