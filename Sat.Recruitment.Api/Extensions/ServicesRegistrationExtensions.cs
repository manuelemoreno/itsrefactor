using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Domain.Repositories;
using Sat.Recruitment.Api.Services.User;

namespace Sat.Recruitment.Api.Extensions;

public static class ServicesRegistrationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserTextFileRepository>();

        return services;
    }
}