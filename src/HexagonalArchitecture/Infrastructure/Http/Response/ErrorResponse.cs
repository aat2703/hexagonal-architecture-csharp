namespace HexagonalArchitecture.Infrastructure.Http.Response;

public class ErrorResponse
{
    public List<ErrorModel> Errors { get; } = new();
    
    public void AddError(ErrorModel error)
    {
        Errors.Add(error);
    }
}