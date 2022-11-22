using Microsoft.Extensions.Logging;
using Sat.Recruitment.Application.Infrastructure.Repositories.Interfaces;
using Sat.Recruitment.Application.Result;
using Sat.Recruitment.Domain.Exceptions;
using Sat.Recruitment.Infrastructure.Dtos;

namespace Sat.Recruitment.Application.Services.User;

public class UserService : IUserService
{
    public readonly IUserRepository UserRepository;
    private readonly ILogger _logger;

    public UserService(ILogger<UserService> logger, IUserRepository userRepository)
    {
        _logger = logger;
        UserRepository = userRepository;
    }

    public async Task<UserServiceResponse> CreateUser(UserServiceRequest userServiceRequest)
    {
        try
        {
            _logger.LogInformation("CreateUserResult");
        var createUser = CreateUsersResult.Create(userServiceRequest);

            if (!createUser.IsSuccess)
                throw new CreateUserException(createUser.Errors);

            if (await IsDuplicateUser(createUser.User))
                throw new DuplicateUserException();

            _logger.LogInformation("SaveUser");
            SaveUser(createUser.User);

            return new UserServiceResponse(true, new List<string>(), createUser.User);
        }

        catch (CreateUserException e)
        {
            _logger.LogError("User has multiple errors in the model request");
            return new UserServiceResponse(false, e.Errors, null);
        }

        catch (DuplicateUserException e)
        {
            _logger.LogError("User already exists");
            var error = new List<string>();
            error.Add(e.Message);
            return new UserServiceResponse(false, error, null);
        }

        catch (Exception e)
        {
            _logger.LogError(e.Message);
            var error = new List<string>();
            error.Add("Unknown Error. Please Contact Support");
            return new UserServiceResponse(false, error, null);
        }
    }

    private async Task<bool> IsDuplicateUser(Domain.Entities.User user)
    {
        var getDuplicateUser = await UserRepository.GetAll();

        return getDuplicateUser.Any(x => x.Email == user.Email.EmailAddress
                                         || x.Phone == user.Phone
                                         || (x.Name == user.Name && x.Address == user.Address));
    }

    private void SaveUser(Domain.Entities.User user)
    {
        var userToSave = new UserDto(user.Name, user.Email.EmailAddress, user.Phone, user.Address,
            user.UserType.ToString(), user.OriginalMoney, user.GiftedAmount);

        UserRepository.SaveUser(userToSave);
    }
}