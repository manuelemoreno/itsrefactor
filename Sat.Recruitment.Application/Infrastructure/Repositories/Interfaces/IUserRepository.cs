using Sat.Recruitment.Infrastructure.Dtos;

namespace Sat.Recruitment.Application.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<UserDto>> GetAll();
    public Task SaveUser(UserDto userDto);
}