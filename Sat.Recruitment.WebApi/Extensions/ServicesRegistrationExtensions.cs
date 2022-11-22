using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Infrastructure.Repositories;
using Sat.Recruitment.Application.Infrastructure.Repositories.Interfaces;
using Sat.Recruitment.Application.Services.User;

namespace Sat.Recruitment.WebApi.Extensions;

public static class ServicesRegistrationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserFileRepository>();

        //Switch to SQL repo
        // services.AddScoped<IUserRepository, UserSqlRepository>();


        return services;
    }
}