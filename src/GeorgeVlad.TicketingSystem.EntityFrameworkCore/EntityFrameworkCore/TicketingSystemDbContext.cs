using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GeorgeVlad.TicketingSystem.Authorization.Roles;
using GeorgeVlad.TicketingSystem.Authorization.Users;
using GeorgeVlad.TicketingSystem.MultiTenancy;
using GeorgeVlad.TicketingSystem.Tickets;

namespace GeorgeVlad.TicketingSystem.EntityFrameworkCore
{
    public class TicketingSystemDbContext : AbpZeroDbContext<Tenant, Role, User, TicketingSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Ticket> Tickets { get; set; }

        public TicketingSystemDbContext(DbContextOptions<TicketingSystemDbContext> options)
            : base(options)
        {
        }
    }
}
