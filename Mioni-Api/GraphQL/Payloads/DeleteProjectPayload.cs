using Mioni_Portfolio.Domain.Entities;

namespace Mioni_Portfolio.GraphQL.Payloads
{
    public record DeleteProjectPayload(Project? DeletedProject, IReadOnlyList<UserError>? Errors = null);
}
