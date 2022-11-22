using Sat.Recruitment.Application.Repositories.Interfaces;
using Sat.Recruitment.Application.Repositories.Dtos;
using Sat.Recruitment.Application.Result;
using Sat.Recruitment.Domain.Exceptions;

namespace Sat.Recruitment.Application.Services.User;

public class UserService : IUserService
{
    public readonly IUserRepository UserRepository;

    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task<UserServiceResponse> CreateUser(UserServiceRequest userServiceRequest)
    {
        try
        {
            var createUser = CreateUsersResult.Create(userServiceRequest);

            if (!createUser.IsSuccess)
                throw new CreateUserException(createUser.Errors);

            if (await IsDuplicateUser(createUser.User))
                throw new DuplicateUserException();

            SaveUser(createUser.User);

            return new UserServiceResponse(true, new List<string>(), createUser.User);
        }

        catch (CreateUserException e)
        {
            return new UserServiceResponse(false, e.Errors, null);
        }

        catch (DuplicateUserException e)
        {
            var error = new List<string>();
            error.Add(e.Message);
            return new UserServiceResponse(false, error, null);
        }

        catch (Exception e)
        {
            //Log Error Message 
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