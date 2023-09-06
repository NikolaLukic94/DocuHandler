using DocumentTemplateMetadata.Application.Common.Interfaces.Persistence;
using DocumentTemplateMetadata.Application.Common.Interfaces.Services;
using static DocumentTemplateMetadata.Application.Common.Interfaces.Persistence.IDocumentTemplateMetadataRepository;

namespace DocumentTemplateMetadata.Infrastructure.Services
{
    public class DocumentTemplateMetadataService : IDocumentTemplateMetadataService
    {
        public List<Domain.Entities.DocumentTemplateMetadata> GetAllDocumentTemplateMetadata()
        {
            throw new NotImplementedException();
        }

        private readonly IDocumentTemplateMetadataRepository _repository;
        public DocumentTemplateMetadataService(IDocumentTemplateMetadataRepository documentTemplateMetadataRepository)
        {
            _repository = documentTemplateMetadataRepository;
        }
        List<Domain.Entities.DocumentTemplateMetadata> IDocumentTemplateMetadataService.GetAllDocumentTemplateMetadata()
        {
            return _repository.GetAllDocumentTemplateMetadata();
        }
    }
}
