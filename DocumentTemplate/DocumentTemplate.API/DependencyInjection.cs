
using DocumentTempate.API.Common.Errors;
using DocumentTempate.API.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace DocumentTemplate.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DocumentTemplateProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }
}