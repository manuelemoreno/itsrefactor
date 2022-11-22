using Sat.Recruitment.Application.Repositories.Dtos;

namespace Sat.Recruitment.Application.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<UserDto>> GetAll();
    public Task SaveUser(UserDto userDto);
}