using Mioni_Portfolio.Domain.Entities;

namespace Mioni_Portfolio.GraphQL.Payloads
{
    public record AddProjectPayload(Project? AddedProject, IReadOnlyList<UserError>? Errors = null);
}
