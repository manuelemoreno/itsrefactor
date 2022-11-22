namespace Sat.Recruitment.Domain.Exceptions;

public class CreateUserException : Exception
{
    public CreateUserException(IEnumerable<string> errors)
        : base("There are some errors in the fields. Please check")
    {
        Errors = errors;
    }

    public IEnumerable<string> Errors { get; }
}