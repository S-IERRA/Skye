namespace Skye.Extensions;

public static class HttpClientExtension
{
    public static HttpClient Modify(this HttpClient client, Action<HttpClient> action)
    {
        action(client);
        return client;
    }

    public static async Task<string> GetResponse(this Task<HttpResponseMessage> responseMessage)
        => await responseMessage.Result.Content.ReadAsStringAsync();
}