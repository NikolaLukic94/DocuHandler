using DocumentTemplateMetadata.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TemplateMetadata = DocumentTemplateMetadata.API.Entities.DocumentTemplateMetadata;

namespace DocumentTemplateMetadata.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DocumentTemplateMetadataController : ControllerBase
    {
        private readonly IDocumentTemplateMetadataRepository _repository;

        public DocumentTemplateMetadataController(IDocumentTemplateMetadataRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{templateName}", Name = "GetTemplateMetadata")]
        [ProducesResponseType(typeof(TemplateMetadata), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TemplateMetadata>> GetDocumentTemplateMetadata(string productName)
        {
            var coupon = await _repository.GetDocumentTemplateMetadata(productName);
            return Ok(coupon);
        }

        [HttpPost]
        [ProducesResponseType(typeof(TemplateMetadata), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TemplateMetadata>> CreateDocumentTemplateMetadata([FromBody] TemplateMetadata coupon)
        {
            await _repository.CreateDocumentTemplateMetadata(coupon);
            return CreatedAtRoute("GetTemplateMetadata", new { name = coupon.Name }, coupon);
        }

        [HttpPut]
        [ProducesResponseType(typeof(TemplateMetadata), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TemplateMetadata>> UpdateDocumentTemplateMetadata([FromBody] TemplateMetadata coupon)
        {
            return Ok(await _repository.UpdateDocumentTemplateMetadata(coupon));
        }

        [HttpDelete("{productName}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteDocumentTemplateMetadata(string productName)
        {
            return Ok(await _repository.DeleteDocumentTemplateMetadata(productName));
        }
    }
}
