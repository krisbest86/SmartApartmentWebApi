using Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RequestModel;
using ResponseModel;

namespace SmartApartmentApi.Controllers
{
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IApiClient apiClient, IConfiguration configuration)
        {
            _apiClient = apiClient;
            _configuration = configuration;
        }

        [HttpGet("/auth/token")]
        public IActionResult GetToken(TokenRequest tokenRequest)
        {
            var result = _apiClient.Post<TokenResponse, TokenRequest>(_configuration["Auth0:GetTokenUrl"], tokenRequest);
            return StatusCode(200, result);
        }
    }

}