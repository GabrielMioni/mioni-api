using Mioni_Portfolio.Domain.Entities;
using Mioni_Portfolio.Services;
using Mioni_Portfolio.Services.Interfaces;

namespace Mioni_Portfolio.GraphQL.Queries
{
    [ExtendObjectType("Query")]
    public class ProjectQueries
    {
        public string Hello()
        {
            return "Hello from ProjectQueries!";
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Project> GetProjects([Service] IProjectDataService service)
        {
            return service.GetAll();
        }

    }
}
