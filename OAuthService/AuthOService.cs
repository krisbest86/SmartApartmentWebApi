using Abstraction;
using Auth0;
using Auth0.AuthenticationApi;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ResponseModel;
using RestSharp;

namespace AuthServices
{
    public class AuthOService : IAuthService
    {
        private readonly RestClient _client;
        public AuthOService(IConfiguration configuration)
        {
            _client = new RestClient(configuration["Auth0:GetTokenUrl"]);


        }

        public TokenResponse GetToken()
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"XIkWDkW0Q7iW6KRTKbfvzWEtpxDybHCY\",\"client_secret\":\"qO7sQlNccbkUZs6Kn3bKuT2W591rsJalJFuM8CVBa0Kwwj_QyZDAsu1J4ZIIa3vU\",\"audience\":\"https://smartapartmentdata/api\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);

            var response = _client.Execute(request);


            return JsonConvert.DeserializeObject<TokenResponse>(response.Content);
        }
    }


    // HasScopeRequirement.cs
}
