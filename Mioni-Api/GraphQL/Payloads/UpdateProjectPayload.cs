using Mioni.Api.Domain.Entities;

namespace Mioni.Api.GraphQL.Payloads
{
    public record UpdateProjectPayload(Project? UpdatedProject, IReadOnlyList<UserError>? Errors = null);
}
