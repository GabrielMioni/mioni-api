namespace Mioni.Api.GraphQL.Payloads
{
    public record UserError(string Message, string? Code = null);
}