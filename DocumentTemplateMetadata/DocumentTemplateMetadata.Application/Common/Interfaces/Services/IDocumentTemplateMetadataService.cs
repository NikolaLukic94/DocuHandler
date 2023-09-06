namespace DocumentTemplateMetadata.Application.Common.Interfaces.Services
{
    public interface IDocumentTemplateMetadataService
    {
        List<Domain.Entities.DocumentTemplateMetadata> GetAllDocumentTemplateMetadata();
    }
}
