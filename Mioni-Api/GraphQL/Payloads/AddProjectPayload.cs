using Mioni_Api.Models;

namespace Mioni_Api.GraphQL.Payloads
{
    public record AddProjectPayload(Project? AddedProject, IReadOnlyList<UserError>? Errors = null);
}
