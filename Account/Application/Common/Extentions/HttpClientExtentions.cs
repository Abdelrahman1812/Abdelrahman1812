using System.Text;
using System.Text.Json;

namespace Account.Application.Common.Extentions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostJsonAsync(this HttpClient httpClient, string url, object body , CancellationToken cancellationToken)
        {
            var bodyJson = JsonSerializer.Serialize(body);
            var stringContent = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            return httpClient.PostAsync(url, stringContent, cancellationToken);
        }
    }
}
