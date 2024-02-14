using Backend.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        const string baseApiUrl = "https://api.freshbooks.com";
        readonly IHttpContextAccessor _httpContextAccessor;

        public InvoicesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get(/*string accountId*/)
        {
            // Retrieve the Authorization header value from the request
            string authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];

            var options = new RestClientOptions(baseApiUrl)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/accounting/account/LJArJ4/invoices/invoices", Method.Get);
            request.AddHeader("Authorization", authorizationHeader);
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
                return Ok(JsonSerializer.Deserialize<InvoiceListDto>(response.Content));
            else throw response.ErrorException;
        }
    }
}
