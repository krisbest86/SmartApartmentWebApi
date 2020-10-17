namespace Abstraction
{
    public interface IApiClient
    {
        T Get<T>(string url) where T : class;
        T Post<T, K>(string url, K requestBody) where T : class;
    }
}