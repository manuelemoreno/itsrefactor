using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services.User;

public interface IUserService
{
    Task<UserServiceResponse> CreateUser(UserServiceRequest userServiceRequest);
}