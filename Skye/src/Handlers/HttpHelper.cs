using System.Net.Http.Headers;
using System.Text;

namespace Skye.Handlers;

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

public static class HttpHelper
{
	private const string Key = "Bearer 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";

	private static readonly HttpClient HttpMod = new HttpClient().Modify(client =>
	{
		client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(Key);
	});

	public static async Task<string> SendAsync(string uri, StringContent content) =>
		await HttpMod.PostAsync(uri, content).GetResponse();

	//public static async
}