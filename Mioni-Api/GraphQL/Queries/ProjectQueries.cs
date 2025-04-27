using Mioni_Api.Domain.Entities;
using Mioni_Api.Services;
using Mioni_Api.Services.Interfaces;

namespace Mioni_Api.GraphQL.Queries
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
        public IQueryable<Project> GetProjects([Service] IProjectService service)
        {
            return service.GetAll();
        }

    }
}
