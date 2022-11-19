using System.Net.Http.Headers;
using Skye.Extensions;

namespace Skye.Handlers;

public static class HttpHelper
{
	private const string Key = "Bearer OPENAI_TOKEN";

	private static readonly HttpClient HttpMod = new HttpClient().Modify(client =>
	{
		client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(Key);
	});

	public static async Task<string> SendAsync(string uri, StringContent content) =>
		await HttpMod.PostAsync(uri, content).GetResponse();
}