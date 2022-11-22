using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.Repositories.Interfaces;
using Sat.Recruitment.Application.Repositories;
using Sat.Recruitment.Application.Services.User;

namespace Sat.Recruitment.WebApi.Extensions;

public static class ServicesRegistrationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserTextFileRepository>();

        return services;
    }
}