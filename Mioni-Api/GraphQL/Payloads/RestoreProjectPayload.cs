using Mioni.Api.Domain.Entities;

namespace Mioni.Api.GraphQL.Payloads
{
    public record RestoreProjectPayload(Project? RestoredProject, IReadOnlyList<UserError>? Errors = null);
}
