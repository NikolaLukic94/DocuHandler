using DocumentTemplateMetadata.API.Helpers;
using DocumentTemplateMetadata.API.Repositories;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDocumentTemplateMetadataRepository, DocumentTemplateMetadataRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var configuration = services.GetRequiredService<IConfiguration>();

    try
    {
        NpgsqlConnection connection;
        NpgsqlCommand command;
        MigrationHelper.RunMigrations(configuration, out connection, out command);
    }
    catch (NpgsqlException ex)
    {
        logger.LogError(ex, "An error occurred while migrating the PostgreSQL database");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

