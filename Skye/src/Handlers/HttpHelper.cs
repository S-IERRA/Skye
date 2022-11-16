using System.Net.Http.Headers;
using Skye.Extensions;

namespace Skye.Handlers;

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