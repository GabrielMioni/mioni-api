using Mioni_Api.Domain.Entities;

namespace Mioni_Api.GraphQL.Payloads
{
    public record UpdateProjectPayload(Project? UpdatedProject, IReadOnlyList<UserError>? Errors = null);
}
