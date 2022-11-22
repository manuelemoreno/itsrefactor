namespace Sat.Recruitment.Application.Services.User;

public class UserServiceResponse : BaseServiceResponse
{
    public UserServiceResponse(bool isSuccess,
                               IEnumerable<string> errors,
                               Domain.Entities.User user) : base(isSuccess, errors)
    {
        User = user;
    }

    public Domain.Entities.User User { get; }
}