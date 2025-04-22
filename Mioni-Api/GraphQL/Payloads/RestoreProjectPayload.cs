using Mioni_Api.Models;

namespace Mioni_Api.GraphQL.Payloads
{
    public record RestoreProjectPayload(Project? RestoredProject, IReadOnlyList<UserError>? Errors = null);
}
