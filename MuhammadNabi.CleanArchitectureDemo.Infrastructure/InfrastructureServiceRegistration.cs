using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Infrastructure;
using MuhammadNabi.CleanArchitectureDemo.Application.Models.Mail;
using MuhammadNabi.CleanArchitectureDemo.Infrastructure.FileExport;
using MuhammadNabi.CleanArchitectureDemo.Infrastructure.Mail;
using System;

namespace MuhammadNabi.CleanArchitectureDemo.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
