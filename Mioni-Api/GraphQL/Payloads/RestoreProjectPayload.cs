using Mioni_Api.Domain.Entities;

namespace Mioni_Api.GraphQL.Payloads
{
    public record RestoreProjectPayload(Project? RestoredProject, IReadOnlyList<UserError>? Errors = null);
}
