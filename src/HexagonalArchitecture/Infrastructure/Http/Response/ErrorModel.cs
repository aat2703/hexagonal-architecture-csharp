namespace HexagonalArchitecture.Infrastructure.Http.Response;

public sealed class ErrorModel
{
    public string? Context { get; set; }

    public string Message { get; set; }
}