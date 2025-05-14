using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Mioni_Portfolio.Domain.Entities;

namespace Mioni_Portfolio.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<ProjectImage> ProjectImages => default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var timeNow = new DateTime(2024, 4, 16, 0, 0, 0, DateTimeKind.Utc);

            var projectBuilder = modelBuilder.Entity<Project>();

            projectBuilder
                .HasMany(p => p.ProjectImages)
                .WithOne(i => i.Project)
                .HasForeignKey(i => i.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            projectBuilder.HasData(
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
