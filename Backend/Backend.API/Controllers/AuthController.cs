using Backend.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Set the API endpoint URL
        const string baseApiUrl = "https://api.freshbooks.com";

        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            // Redirect the user to Freshbooks authorization page
            return Redirect("https://auth.freshbooks.com/oauth/authorize/?response_type=code&redirect_uri=https://localhost:44357/api/Auth/callback&client_id=b9cc850e28a92f4792edfe74aa9cc494b203f36be47c56b6a76a108de8eeaad2");
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Authorization code not found in the request.");
            }

            try
            {
                // Exchange the authorization code for an access token
                var token = await ExchangeAuthorizationCodeForAccessToken(code);

                // Redirect the user to the frontend dashboard route with the access token as a query parameter
                return Redirect($"http://localhost:5173/dashboard?access_token={token.AccessToken}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error exchanging authorization code for access token: {ex.Message}");
            }
        }

        private async Task<TokenDto> ExchangeAuthorizationCodeForAccessToken(string code)
        {
            var options = new RestClientOptions(baseApiUrl)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/auth/oauth/token", Method.Post);

            // Set the required parameters
            var requestContent = new
            {
                grant_type = "authorization_code",
                client_id = "b9cc850e28a92f4792edfe74aa9cc494b203f36be47c56b6a76a108de8eeaad2",
                code = code,
                client_secret = "4b11f6c980e9c947dec3fb700b3ebe34592382c93a0a9dfdcc7dcc20cfc0c93c",
                redirect_uri = "https://localhost:44357/api/Auth/callback"
            };

            // Set the request headers
            request.AddHeader("Content-Type", "application/json");

            // Set the request body
            request.AddJsonBody(requestContent);

            // Execute the request
            RestResponse response = await client.ExecuteAsync(request);

            // Handle the response
            if (response.IsSuccessful)
                return JsonSerializer.Deserialize<TokenDto>(response.Content);
            else throw response.ErrorException;
        }
    }
}
