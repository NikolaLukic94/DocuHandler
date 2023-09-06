namespace DocumentTemplateMetadata.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        //services.AddSingleton<ProblemDetailsFactory, DocumentTemplateProblemDetailsFactory>();
        //services.AddMappings();

        return services;
    }
}