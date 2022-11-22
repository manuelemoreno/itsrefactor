using Sat.Recruitment.Application.Services.User;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Result;

public class CreateUsersResult
{
    private CreateUsersResult(User user,
                              IEnumerable<string> errorList,
                              bool success)
    {
        User = user;
        Errors = errorList;
        IsSuccess = success;
    }

    public User User { get; }
    public bool IsSuccess { get; set; }
    public IEnumerable<string> Errors { get; set; }

    public static CreateUsersResult Create(UserServiceRequest request)
    {
        var getErrors = GetErrors(request);

        if (getErrors.Count > 0) return new CreateUsersResult(null, getErrors, false);

        var user = User.Create(request.Name, request.Email, request.Address, request.Phone, request.UserType,
            request.OriginalMoney);

        return new CreateUsersResult(user, new List<string>(), true);
    }

    private static List<string> GetErrors(UserServiceRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(request.Name))
            errors.Add("The name is required");

        if (string.IsNullOrEmpty(request.Email))
            errors.Add("The email is required");

        if (string.IsNullOrEmpty(request.Address))
            errors.Add("The address is required");

        if (string.IsNullOrEmpty(request.Phone))
            errors.Add("The phone is required");

        return errors;
    }
}