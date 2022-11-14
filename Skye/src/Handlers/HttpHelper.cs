using System.Text;

namespace Skye.Handlers;

public static class HttpHelper
{
	private static readonly HttpClient HttpMod = new();

	public static async Task<HttpResponseMessage> SendAsync(string uri, StringContent content) =>
		await HttpMod.PostAsync(uri, content);

	//public static async
}