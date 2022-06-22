using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuhammadNabi.CleanArchitectureDemo.Identity.Models;

namespace MuhammadNabi.CleanArchitectureDemo.Identity
{
    public class GloboTicketIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public GloboTicketIdentityDbContext(DbContextOptions<GloboTicketIdentityDbContext> options) : base(options)
        {
        }
    }
}
