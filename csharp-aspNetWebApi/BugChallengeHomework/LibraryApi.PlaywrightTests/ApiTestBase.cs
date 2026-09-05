using System.Text.Json;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace LibraryApi.PlaywrightTests;

public abstract class ApiTestBase : PlaywrightTest
{
    protected IAPIRequestContext Api { get; private set; } = null!;

    protected static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    protected static string BaseUrl =>
        Environment.GetEnvironmentVariable("API_BASE_URL") ?? "https://localhost:7205";

    [SetUp]
    public async Task CreateApiContext()
    {
        Api = await Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = BaseUrl,
            IgnoreHTTPSErrors = true,
            ExtraHTTPHeaders = new Dictionary<string, string>
            {
                ["Accept"] = "application/json"
            }
        });
    }

    [TearDown]
    public async Task DisposeApiContext()
    {
        await Api.DisposeAsync();
    }

    protected static async Task<T> ReadJsonAsync<T>(IAPIResponse response)
    {
        var text = await response.TextAsync();
        var value = JsonSerializer.Deserialize<T>(text, JsonOptions);
        Assert.That(value, Is.Not.Null, $"Expected JSON body, got: {text}");
        return value!;
    }
}
