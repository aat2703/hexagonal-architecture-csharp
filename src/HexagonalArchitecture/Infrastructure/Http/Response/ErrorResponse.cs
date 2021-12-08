namespace HexagonalArchitecture.Infrastructure.Http.Response;

public class ErrorResponse
{
    public List<ErrorModel> Errors { get; }
    
    public ErrorResponse(List<ErrorModel> errors)
    {
        Errors = errors;
    }
}