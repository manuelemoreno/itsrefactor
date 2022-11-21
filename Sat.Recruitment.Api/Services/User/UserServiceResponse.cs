using System.Collections.Generic;
using Sat.Recruitment.Api.Services;

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