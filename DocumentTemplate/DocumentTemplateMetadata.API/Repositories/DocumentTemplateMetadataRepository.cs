using Dapper;
using Npgsql;
using TemplateMetadata = DocumentTemplateMetadata.API.Entities.DocumentTemplateMetadata;


namespace DocumentTemplateMetadata.API.Repositories
{
    public class DocumentTemplateMetadataRepository : IDocumentTemplateMetadataRepository
    {
        private readonly IConfiguration _configuration;

        public DocumentTemplateMetadataRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<TemplateMetadata> GetDocumentTemplateMetadata(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<TemplateMetadata>
                ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (coupon == null)
                return new TemplateMetadata
                { Name = "No Discount", EditionDate = new DateTime() };

            return coupon;
        }

        public async Task<bool> CreateDocumentTemplateMetadata(TemplateMetadata coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                            new { Name = coupon.Name, EditionDate = coupon.EditionDate });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> UpdateDocumentTemplateMetadata(TemplateMetadata coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
                    ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                            new { ProductName = coupon.Name, EditionDate = coupon.EditionDate, Id = coupon.Id });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDocumentTemplateMetadata(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });

            if (affected == 0)
                return false;

            return true;
        }
    }
}