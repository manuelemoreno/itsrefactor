using System.Collections.Generic;

namespace Sat.Recruitment.Api.Services.User;

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