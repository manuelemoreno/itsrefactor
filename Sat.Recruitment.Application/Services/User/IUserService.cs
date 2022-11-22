namespace Sat.Recruitment.Application.Services.User;

public interface IUserService
{
    Task<UserServiceResponse> CreateUser(UserServiceRequest userServiceRequest);
}