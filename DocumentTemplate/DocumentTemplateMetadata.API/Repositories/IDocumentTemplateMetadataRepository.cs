using TemplateMetadata = DocumentTemplateMetadata.API.Entities.DocumentTemplateMetadata;

namespace DocumentTemplateMetadata.API.Repositories
{
    public interface IDocumentTemplateMetadataRepository
    {
        Task<TemplateMetadata> GetDocumentTemplateMetadata(string productName);
        Task<bool> CreateDocumentTemplateMetadata(TemplateMetadata coupon);
        Task<bool> UpdateDocumentTemplateMetadata(TemplateMetadata coupon);
        Task<bool> DeleteDocumentTemplateMetadata(string productName);
    }
}
