namespace Mioni_Api.GraphQL.Payloads
{
    public record UserError(string Message, string? Code = null);
}