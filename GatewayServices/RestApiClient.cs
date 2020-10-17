using Abstraction;
using Newtonsoft.Json;
using RestSharp;

namespace ApiServices
{
    public class RestApiClient : IApiClient
    {
        public T Get<T>(string url) where T : class
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public T Post<T, K>(string url, K requestBody) where T : class
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(requestBody), ParameterType.RequestBody);

            var response = client.Execute(request);


            return JsonConvert.DeserializeObject<T>(response.Content);
        }


    }
}
