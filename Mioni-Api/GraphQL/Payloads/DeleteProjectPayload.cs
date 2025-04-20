using Mioni_Api.Models;

namespace Mioni_Api.GraphQL.Payloads
{
    public record DeleteProjectPayload(Project? DeletedProject, IReadOnlyList<UserError>? Errors = null);
}
