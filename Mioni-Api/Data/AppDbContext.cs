using Microsoft.EntityFrameworkCore;
using Mioni_Api.Models;

namespace Mioni_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects => Set<Project>();
    }
}
