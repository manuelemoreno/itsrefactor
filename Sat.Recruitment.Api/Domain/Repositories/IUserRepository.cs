using System.Collections.Generic;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Domain.Repositories.Dtos;

namespace Sat.Recruitment.Api.Domain.Repositories;

public interface IUserRepository
{
    public Task<List<UserDto>> GetAll();
    public Task SaveUser(UserDto userDto);
}