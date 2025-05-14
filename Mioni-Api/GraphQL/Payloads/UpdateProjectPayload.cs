using Mioni_Portfolio.Domain.Entities;

namespace Mioni_Portfolio.GraphQL.Payloads
{
    public record UpdateProjectPayload(Project? UpdatedProject, IReadOnlyList<UserError>? Errors = null);
}
