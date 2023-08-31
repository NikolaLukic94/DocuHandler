
using DocumentTempate.API.Common.Errors;
using DocumentTempate.API.Common.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DocumentTemplate.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DocumentTemplateProblemDetailsFactory>();
        services.AddMappings();

        services.Configure<IdentityOptions>(options =>
        {
            // Account lockout settings
            options.Lockout.MaxFailedAccessAttempts = 5; // Number of failed attempts before lockout
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30); // Lockout duration

            // Password policy settings
            options.Password.RequiredLength = 8; // Minimum password length
            options.Password.RequireDigit = true; // Require at least one digit
            options.Password.RequireNonAlphanumeric = true; // Require at least one non-alphanumeric character
            options.Password.RequireUppercase = true; // Require at least one uppercase letter
            options.Password.RequireLowercase = true; // Require at least one lowercase letter
        });

        return services;
    }
}