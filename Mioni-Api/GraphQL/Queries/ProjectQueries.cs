using Mioni.Api.Domain.Entities;
using Mioni.Api.Services;
using Mioni.Api.Services.Interfaces;

namespace Mioni.Api.GraphQL.Queries
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
