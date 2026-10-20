using System.Net;

namespace Lamazon.Web.Middlewares;

public class DebugIpAddressMidleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpClientFactory _httpClientFactory;

    public DebugIpAddressMidleware(RequestDelegate next, IHttpClientFactory httpClientFactory)
    {
        this._next = next;
        this._httpClientFactory = httpClientFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ipAddress = context.Connection.RemoteIpAddress?.ToString();

        if (string.IsNullOrEmpty(ipAddress) || IPAddress.IsLoopback(IPAddress.Parse(ipAddress)))
        {
            ipAddress = await GetPublicIpAddressAsync();
        }

        context.Items["IpAddress"] = ipAddress;

        await _next(context);
    }

    private async Task<string?> GetPublicIpAddressAsync()
    {
        try
        {
            using var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            var response = await client.GetAsync("https://api.ipify.org?format=json");
            if (IPAddress.TryParse(await response.Content.ReadAsStringAsync(), out var ipAddress))
            {
                return ipAddress.ToString();
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}
