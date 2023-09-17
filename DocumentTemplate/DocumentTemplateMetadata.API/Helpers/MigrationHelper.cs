using Npgsql;

namespace DocumentTemplateMetadata.API.Helpers
{
    public static class MigrationHelper
    {
        public static void RunMigrations(IConfiguration configuration, out NpgsqlConnection connection, out NpgsqlCommand command)
        {
            var connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            command = new NpgsqlCommand
            {
                Connection = connection
            };
            command.CommandText = "DROP TABLE IF EXISTS DocumentTemplateMetadata";
            command.ExecuteNonQuery();

            command.CommandText = @"CREATE TABLE DocumentTemplateMetadata(Id SERIAL PRIMARY KEY, 
                                                    Name VARCHAR(24) NOT NULL,
                                                    EditionDate TIMESTAMP)";
            command.ExecuteNonQuery();
        }
    }
}
