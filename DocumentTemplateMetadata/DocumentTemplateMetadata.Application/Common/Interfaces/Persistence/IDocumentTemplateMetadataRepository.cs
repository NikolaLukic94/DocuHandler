namespace DocumentTemplateMetadata.Application.Common.Interfaces.Persistence
{
    public interface IDocumentTemplateMetadataRepository
    {
        public interface IMemberRepository
        {
            List<Domain.Entities.DocumentTemplateMetadata> GetAllDocumentTemplateMetadata();
        }
    }
}
