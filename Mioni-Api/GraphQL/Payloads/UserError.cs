namespace Mioni_Portfolio.GraphQL.Payloads
{
    public record UserError(string Message, string? Code = null);
}