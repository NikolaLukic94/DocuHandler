using DocumentTemplate.Application.Common.Interfaces.Authentication;
using DocumentTemplate.Application.Common.Interfaces.Persistence;
using DocumentTemplate.Application.Common.Interfaces.Services;
using DocumentTemplate.Infrastructure.Authentication;
using DocumentTemplate.Infrastructure.Persistence;
using DocumentTemplate.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}