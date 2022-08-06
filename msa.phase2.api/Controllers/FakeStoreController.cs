using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace msa.phase2.api.Controllers
{
    
    [ApiController]
    [Route("FakeStore")]
    public class FakeStoreController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public FakeStoreController(IHttpClientFactory clientFactory)
        {
            if (clientFactory == null)
            {
                throw new ArgumentNullException(nameof(clientFactory));

            }
            _httpClient = clientFactory.CreateClient("FakeStore");
        }

        /// <summary>
        /// Gets the raw JSON from the FakeStore API
        /// </summary>
        /// <returns> A JSON object representing products in fakestore</returns>
        [HttpGet]
        [Route("products")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllProducts()
        {
            var res = await _httpClient.GetAsync("/products");
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
    
}
