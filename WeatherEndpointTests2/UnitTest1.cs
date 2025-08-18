// Tento testovací soubor ovìøuje funkènost endpointu /weatherforecast ve webové aplikaci.
// Používá xUnit a tøídu WebApplicationFactory k vytvoøení testovací instance aplikace,
// díky èemuž není potøeba spouštìt aplikaci "naživo". 
// 
// Tøída WeatherEndpointTests2 implementuje IClassFixture<WebApplicationFactory<Program>>,
// což znamená, že pro každý test se vytvoøí HttpClient napojený na testovací server.
// 
// Konkrétní test Get_WeatherForecast_ReturnsOk odešle GET požadavek na /weatherforecast
// a oèekává odpovìï se stavovým kódem 200 OK. 
// Tím ovìøuje, že endpoint funguje a aplikace vrací validní odpovìï.
//
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

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
