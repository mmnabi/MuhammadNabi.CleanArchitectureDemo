﻿using Microsoft.EntityFrameworkCore;
using Moq;
using MuhammadNabi.CleanArchitectureDemo.Application.Contracts;
using MuhammadNabi.CleanArchitectureDemo.Domain.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MuhammadNabi.CleanArchitectureDemo.Persistence.IntegrationTests
{
    public class GloboTicketDbContextTests
    {
        private readonly GloboTicketDbContext _globoTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _globoTicketDbContext.Events.Add(ev);
            await _globoTicketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
