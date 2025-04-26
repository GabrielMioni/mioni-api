using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Mioni_Api.Domain.Entities;

namespace Mioni_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects => Set<Project>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var timeNow = new DateTime(2024, 4, 16, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "Seeded Project 1",
                    Description = "Description for Project 1",
                    CreatedAt = timeNow,
                    UpdatedAt = timeNow
                },
                new Project
                {
                    Id = 2,
                    Title = "Seeded Project 2",
                    Description = "Description for Project 2",
                    CreatedAt = timeNow,
                    UpdatedAt = timeNow
                }
            );
        }
    }
}
