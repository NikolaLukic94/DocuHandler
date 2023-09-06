using DocumentTemplateMetadata.Application.Common.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentTemplateMetadata.Infrastructure.Persistence
{
    public class DocumentTemplateMetadataRepository : IDocumentTemplateMetadataRepository
    {
        public static List<Domain.Entities.DocumentTemplateMetadata> list = new List<Domain.Entities.DocumentTemplateMetadata>()
        {
           new Domain.Entities.DocumentTemplateMetadata{  Id =1 ,Name= "Kirtesh Shah", EditionDate=DateTime.Now},
           new Domain.Entities.DocumentTemplateMetadata{  Id =1 ,Name= "Kirtesh Shah", EditionDate=DateTime.Now},
        };
        public List<Domain.Entities.DocumentTemplateMetadata> GetDocumentTemplateMetadata()
        {
            return list;
        }
    }
}
