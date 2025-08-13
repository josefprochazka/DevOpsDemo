using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

public class WeatherEndpointTests2 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public WeatherEndpointTests2(WebApplicationFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task Get_WeatherForecast_ReturnsOk()
    {
        var resp = await _client.GetAsync("/weatherforecast");
        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }
}
