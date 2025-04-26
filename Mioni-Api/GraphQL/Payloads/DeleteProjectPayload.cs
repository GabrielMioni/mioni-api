using Mioni_Api.Domain.Entities;

namespace Mioni_Api.GraphQL.Payloads
{
    public record DeleteProjectPayload(Project? DeletedProject, IReadOnlyList<UserError>? Errors = null);
}
