using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Configurations;

namespace Sat.Recruitment.Api.Extensions;

public static class OptionsRegistrationExtensions
{
    public static IServiceCollection AddOptions(this IServiceCollection services,
                                                IConfiguration configuration)
    {
        services.Configure<AuthTokenOptions>(configuration.GetSection("Auth"));

        return services;
    }
}