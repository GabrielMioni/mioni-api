using Mioni_Api.Models;
using System.Collections.Generic;

namespace Mioni_Api.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ProjectQueries
    {
        public string Hello()
        {
            return "Hello from ProjectQueries!";
        }
        public IEnumerable<Project> GetProjects()
        {
            return new List<Project>
            {
                new Project {
                    Id = 1,
                    Title = "Project 1",
                    Description = "Description of Project 1",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Project
                {
                    Id = 2,
                    Title = "Project 2",
                    Description = "Description of Project 2",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
        }

    }
}
