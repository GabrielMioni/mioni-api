using Mioni_Api.Models;
using Mioni_Api.Services;

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
        public IQueryable<Project> GetProjects([Service] ProjectService service)
        {
            return service.GetAll();
        }

    }
}
