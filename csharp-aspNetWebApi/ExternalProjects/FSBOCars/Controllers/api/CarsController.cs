using Microsoft.AspNetCore.Mvc;

namespace FSBOCars.Controllers.api;

[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CarsController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        var baseUrl = _configuration["MarketCheck:BaseUrl"];
        if (string.IsNullOrEmpty(baseUrl))
        {
            throw new InvalidOperationException("BaseUrl not found in configuration.");
        }
        _httpClient.BaseAddress = new Uri(baseUrl);

    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string? make, string? model, int? year, decimal? priceMax, string? zip, int? radius)
    {
        //Api key from appsettings.json
        var apiKey = _configuration["MarketCheck:ApiKey"];

        //
        var url = $"search/car/fsbo/active?api_key={apiKey}";

        if (!string.IsNullOrEmpty(make))
        {
            url += $"&make={make}";    
        }
        if (!string.IsNullOrEmpty(model))
        {
            url += $"&model={model}";
        }
        if (year.HasValue)
        {
            url += $"&year={year}";
        }
        if (priceMax.HasValue)
        {
            url += $"&price_max={priceMax}";
        }
        if (!string.IsNullOrEmpty(zip))
        {
            url += $"&zip={zip}";
        }
        if (radius.HasValue)
        {
            url += $"&radius={radius}";
        }

        //call the external Api
        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, new {error = 
                "Unable to reach car search service"});
        }

        //return the json into the browser
        var json = await response.Content.ReadAsStringAsync();
        return Content(json, "application/json");
    }
}
