namespace HexagonalArchitecture.Api.Infrastructure.Http.Response;

public sealed class ErrorResponse
{
    public List<ErrorModel> Errors { get; }
    
    public ErrorResponse(List<ErrorModel> errors)
    {
        Errors = errors;
    }
}