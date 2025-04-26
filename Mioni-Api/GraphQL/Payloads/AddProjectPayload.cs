using Mioni_Api.Domain.Entities;

namespace Mioni_Api.GraphQL.Payloads
{
    public record AddProjectPayload(Project? AddedProject, IReadOnlyList<UserError>? Errors = null);
}
