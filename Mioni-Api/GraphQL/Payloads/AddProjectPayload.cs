using Mioni.Api.Domain.Entities;

namespace Mioni.Api.GraphQL.Payloads
{
    public record AddProjectPayload(Project? AddedProject, IReadOnlyList<UserError>? Errors = null);
}
