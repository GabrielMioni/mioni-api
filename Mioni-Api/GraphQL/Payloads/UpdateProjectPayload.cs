using Mioni_Api.Models;

namespace Mioni_Api.GraphQL.Payloads
{
    public record UpdateProjectPayload(Project? UpdatedProject, IReadOnlyList<UserError>? Errors = null);
}
