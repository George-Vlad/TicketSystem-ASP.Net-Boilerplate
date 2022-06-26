using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GeorgeVlad.TicketingSystem.EntityFrameworkCore
{
    public static class TicketingSystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TicketingSystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TicketingSystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
