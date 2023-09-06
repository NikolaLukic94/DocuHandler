using DocumentTemplateMetadata.Application.Common.Interfaces.Persistence;
using DocumentTemplateMetadata.Application.Common.Interfaces.Services;
using DocumentTemplateMetadata.Infrastructure.Persistence;
using DocumentTemplateMetadata.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentTemplateMetadata.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddSingleton<IDocumentTemplateMetadataService, DocumentTemplateMetadataService>();
        services.AddScoped<IDocumentTemplateMetadataRepository, DocumentTemplateMetadataRepository>();

        return services;
    }
}