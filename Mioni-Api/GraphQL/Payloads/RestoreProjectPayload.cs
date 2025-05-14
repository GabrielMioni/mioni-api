using Mioni_Portfolio.Domain.Entities;

namespace Mioni_Portfolio.GraphQL.Payloads
{
    public record RestoreProjectPayload(Project? RestoredProject, IReadOnlyList<UserError>? Errors = null);
}
