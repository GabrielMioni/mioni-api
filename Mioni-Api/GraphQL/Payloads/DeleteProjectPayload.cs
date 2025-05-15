using Mioni.Api.Domain.Entities;

namespace Mioni.Api.GraphQL.Payloads
{
    public record DeleteProjectPayload(Project? DeletedProject, IReadOnlyList<UserError>? Errors = null);
}
