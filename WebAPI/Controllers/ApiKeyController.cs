using Application.DTOs.ApiKeyDTOs.AddApiKey;
using Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("admin/[controller]")]
    [ApiController]
    public class ApiKeyController : ControllerBase
    {
        private readonly IApiKey apiKey;

        public ApiKeyController(IApiKey apiKey)
        {
            this.apiKey = apiKey;
        }

        [HttpPost("addApiKey")]
        public async Task<ActionResult<AddApiKeyResponse>> AddApiKeyAsync(AddApiKeyDTO addApiKeyDTO)
        {
            var result = await apiKey.AddApiKeyAsync(addApiKeyDTO);
            return Ok(result);
        }
    }
}
