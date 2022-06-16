﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts.Persistence;
using MuhammadNabi.CleanArchitectureDemo.Persistence.Repositories;

namespace MuhammadNabi.CleanArchitectureDemo.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GloboTicketTicketManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
