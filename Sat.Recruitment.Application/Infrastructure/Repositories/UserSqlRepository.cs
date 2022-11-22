using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sat.Recruitment.Application.Infrastructure.Repositories.Interfaces;
using Sat.Recruitment.Domain.Configuration;
using Sat.Recruitment.Infrastructure;
using Sat.Recruitment.Infrastructure.Dtos;

namespace Sat.Recruitment.Application.Infrastructure.Repositories;

public class UserSqlRepository : IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserSqlRepository()
    {
        _applicationDbContext = new ApplicationDbContext();

    }


    public async Task<List<UserDto>> GetAll()
        => await _applicationDbContext.User.ToListAsync();

    public async Task SaveUser(UserDto userDto)
    {
        _applicationDbContext.User.Add(userDto);
        await _applicationDbContext.SaveChangesAsync();

    }

}