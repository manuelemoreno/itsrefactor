namespace Sat.Recruitment.Application.Services;

public class BaseServiceResponse
{
    public BaseServiceResponse(bool isSuccess,
                               IEnumerable<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public bool IsSuccess { get; set; }
    public IEnumerable<string> Errors { get; set; }
}